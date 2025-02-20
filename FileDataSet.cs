using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InformationSystem_Lab_2
{
	public class FileDataSet
	{
		private const string USERS_FILE = "users.UserData";
		private const string ATTEMPTS_FILE = "attempts.LoginAttemptsData";
		private const string CONFIGS_FILE = "configs.ConfigsData";
		private const string BLOCKS_FILE = "blocks.BlockData";
		private const string LOGS_FILE = "logs.EventLogData";
		private const string ADMINS_FILE = "admins.Guid";
		private const string ARCHIVE_DIR = "archive";

		public static readonly string MaxLoginAttempts = "MaxLoginAttempts";
		public static readonly string AfkDelay = "AfkDelay";
		public static readonly string LastArchiveDate = "LastArchiveDate";
		private static Dictionary<string, ConfigData> DEFAULT_CONFIGS => new Dictionary<string, ConfigData>()
		{
			{ MaxLoginAttempts, new ConfigData(MaxLoginAttempts, "3", 
				value => int.TryParse(value, out int data) && data > 0 && data <= 10,
				"число в диапозоне от 1 до 10") },
			{ AfkDelay, new ConfigData(AfkDelay, "15м",
				value => "смч".Contains(value.Last()) && 
					int.TryParse(value.Substring(0, value.Length-1), out int data) && 
					data > 0 && data < int.MaxValue,
				"число больше 0 + с|м|ч") },
			{ LastArchiveDate, new ConfigData(LastArchiveDate, "Не трогать", 
				value => false, "не трогать это значение") },
		};
		public static readonly Guid SYSTEM_UUID = Guid.NewGuid();

		public FileDataSet()
		{
			foreach (string file in new string[] { 
				USERS_FILE, ATTEMPTS_FILE, CONFIGS_FILE, 
				BLOCKS_FILE, LOGS_FILE, ADMINS_FILE
			})
			{
				if (File.Exists(file) == false)
				{
					File.Create(file).Close();
				}
			}
			StartWatcher();
		}

		private void StartWatcher(bool restart = false)
		{
			Process watcher = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "python",
					Arguments = Properties.Resources.watcher_script + (restart ? " True" : ""),
					UseShellExecute = false,
					CreateNoWindow = true,
				},
				EnableRaisingEvents = true,
			};
			watcher.Exited += Watcher_Exited;
			watcher.Start();
		}

		private void Watcher_Exited(object sender, EventArgs e)
		{
			StartWatcher(true);
		}

		public Guid VerifyPassword(
			string login, string password, out bool result,
			out bool blocked, out int attempts)
		{
			Guid uuid = Guid.Empty;
			result = false;
			blocked = false;
			foreach (UserData user in selectUsersData(u => u.login == login))
			{
				uuid = user.uuid;
				if (user.password == password)
					result = true;
				break;
			}
			blocked = getUuidBlock(uuid);
			attempts = getLoginAttemptsCount(uuid);

			if (uuid == Guid.Empty)
				return Guid.Empty;
			return uuid;
		}

		public void FirstLoginAttempt(Guid uuid)
		{
			if (uuid == Guid.Empty)
				return;
			createLine(ATTEMPTS_FILE, new LoginAttemptsData(uuid));
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.LoginFailture, uuid, getIp(),
				"Пользователь неудачно авторизовался в системе."));
		}

		public void AddLoginAttempt(Guid uuid)
		{
			if (uuid == Guid.Empty)
				return;
			updateAttempts(
				a => a.uuid == uuid,
				a => a.AddAttempt()
			);
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.LoginFailture, uuid, getIp(),
				"Пользователь неудачно авторизовался в системе."));
		}

		public void LogIn(Guid uuid)
		{
			deleteLoginAttempts(a => a.uuid == uuid);
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserLogIn, uuid, getIp(),
				"Пользователь успешно авторизовался в системе."));
		}

		public void ReLogIn(Guid before_uuid, Guid after_uuid)
		{
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserReLogIn, before_uuid, getIp(),
				$"Пользователь авторизовался в системе под другой учётной записью(uuid={after_uuid})."));
		}

		public void LogOut(Guid uuid, bool isAfk = false)
		{
			if (isAfk)
				createLine(LOGS_FILE, new EventLogData(
					EventLogData.EventLogType.UserAfk, uuid, getIp(),
					"Пользователь не активен, осуществлён выход из системы."));
			else
				createLine(LOGS_FILE, new EventLogData(
					EventLogData.EventLogType.UserLogOut, uuid, getIp(),
					"Пользователь самостоятельно вышел из системы."));
		}

		public bool IsAdmin(Guid uuid)
		{
			if (uuid == SYSTEM_UUID)
				return true;
			string userUuid = uuid.ToString();
			foreach (string line in readLines(ADMINS_FILE))
			{
				if (userUuid.Equals(line))
					return true;
			}
			return false;
		}

		public Guid TryRegister(string login, string password, 
			Guid adminUuid, out bool result, out bool denied)
		{
			result = false;
			denied = false;

			if (IsAdmin(adminUuid) == false)
			{
				denied = true;
				return Guid.Empty;
			}

			Guid uuid = getUserUuid(login);
			if (uuid != Guid.Empty)
				return Guid.Empty;

			UserData user = new UserData(login, password);
			createLine(USERS_FILE, user);
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserRegisrated, user.uuid, getIp(), 
				"Новый пользователь зарегистрировался в системе."));
			result = true;
			return user.uuid;
		}

		public void UnBlockIfNot(Guid uuid, Guid adminUuid, out bool denied)
		{
			denied = false;
			if (IsAdmin(adminUuid) == false)
			{
				denied = true;
				return;
			}
			if (uuid == Guid.Empty)
				return;
			deleteLines(BLOCKS_FILE, new BlockData(), data => (data as BlockData).uuid == uuid);
			deleteLines(ATTEMPTS_FILE, new LoginAttemptsData(), data => (data as LoginAttemptsData).uuid == uuid);
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserUnBlocked, uuid, getIp(), 
				$"Пользователь был разблокирован администратором (uuid: {adminUuid})"));
		}

		public void BlockIfNot(Guid uuid, string reason, Guid adminUuid, out bool denied)
		{
			denied = false;
			if (IsAdmin(adminUuid) == false)
			{
				denied = true;
				return;
			}
			if (uuid == Guid.Empty)
				return;
			foreach(BlockData block in selectBlockData(b => b.uuid == uuid && b.reason == reason))
				return;
			createLine(BLOCKS_FILE, new BlockData(uuid, reason));
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserBlocked, uuid, getIp(), 
				$"Пользователь был заблокирован {(adminUuid == SYSTEM_UUID ? "системой" : $"администратором (uuid: {adminUuid})")}. Причина: {reason}"));
		}

		public IEnumerable<EventLogData> GetEventsLogs(Guid adminUuid, out bool denied)
		{
			denied = false;
			if (IsAdmin(adminUuid) == false)
			{
				denied = true;
				return null;
			}
			return readFileData(LOGS_FILE, new EventLogData()).Cast<EventLogData>();
		}

		#region Get
		public (UserData[] users, BlockData[] blockedUsers, Guid[] admins) GetBLockedUsers()
		{
			UserData[] users = selectUsersData().ToArray();
			BlockData[] blockedUsers = selectBlockData().ToArray();
			Guid[] admins = readLines(ADMINS_FILE).Select(line => Guid.Parse(line)).ToArray();
			return (users, blockedUsers, admins);
		}
		private IPAddress getIp()
		{
			IPAddress[] hosts = Dns.GetHostAddresses(Dns.GetHostName());
			if (hosts.Length == 0 || hosts[0].Equals(IPAddress.Loopback))
				return IPAddress.None;
			return hosts[0];
		}

		public bool GetLoginBlock(string login)
		{
			Guid uuid = getUserUuid(login);
			return getUuidBlock(uuid);
		}

		private bool getUuidBlock(Guid uuid)
		{
			if (uuid != Guid.Empty)
				foreach (BlockData block in selectBlockData(b => b.uuid == uuid))
					return true;
			return false;
		}

		public ConfigData[] GetConfigs()
		{
			Dictionary<string, ConfigData> configs = DEFAULT_CONFIGS;
			foreach (ConfigData config in selectConfigData())
			{
				configs[config.name].SetData(config.data);
			}
			return configs.Select(c => c.Value).ToArray();
		}

		public void SetConfig(string name, string value, Guid adminUuid, out string result, out bool denied)
		{
			denied = false;
			result = null;
			if (IsAdmin(adminUuid) == false)
			{
				denied = true;
				return;
			}
			if (DEFAULT_CONFIGS.ContainsKey(name) == false)
			{
				throw new KeyNotFoundException($"'{name}' - несуществующее имя конфига!");
			}
			Dictionary<string, ConfigData> configs = DEFAULT_CONFIGS;
			if (configs.ContainsKey(name))
			{
				var configData = configs[name];
				deleteLines(CONFIGS_FILE, new ConfigData(), data => (data as ConfigData).name == name);

				if (value == configData.data)
				{
					result = null;
				}
				else if (value == null)
				{
					result = $"Конфигурация `{name}` выставлено в значение по умолчанию.";
					createLine(LOGS_FILE, new EventLogData(
						EventLogData.EventLogType.ConfigChanged, adminUuid, getIp(),
						$"Администратор изменил конфигурацию `{name} на значение по умолчанию `{configData.data}`."));
				}
				else if (configData.SetData(value))
				{
					createLine(CONFIGS_FILE, configData);
					result = $"Конфигурация `{name}` успешно изменена.";
					createLine(LOGS_FILE, new EventLogData(
						EventLogData.EventLogType.ConfigChanged, adminUuid, getIp(),
						$"Администратор изменил конфигурацию `{name}` на значение `{value}`."));
				}
				else
				{
					if (name == LastArchiveDate && adminUuid == SYSTEM_UUID)
					{
						createLine(CONFIGS_FILE, new ConfigData(LastArchiveDate, value, null, null));
						createLine(LOGS_FILE, new EventLogData(
							EventLogData.EventLogType.ConfigChanged, adminUuid, getIp(),
							$"Конфигурации `{name}` изменена системой на значение `{value}`."));
						result = $"Конфигурации `{name}` изменена системой на значение `{value}`.";
						return;
					}
					result = $"Для конфигурации `{name}` значение `{value}` не подходит, требуется `{configData.note}`.";
				}
			}
		}

		public string GetConfig(string configName)
		{
			if (DEFAULT_CONFIGS.ContainsKey(configName) == false)
			{
				throw new KeyNotFoundException($"'{configName}' - несуществующее имя конфига!");
			}

			foreach (ConfigData config in selectConfigData(c => c.name == configName))
			{
				return config.data;
			}
			return DEFAULT_CONFIGS[configName].data;
		}

		private Guid getUserUuid(string login)
		{
			foreach (UserData user in selectUsersData(u => u.login == login))
			{
				return user.uuid;
			}
			return Guid.Empty;
		}

		private int getLoginAttemptsCount(Guid uuid)
		{
			if (uuid == Guid.Empty)
				return 0;
			foreach (LoginAttemptsData attempts in selectLoginAttempts(a => a.uuid == uuid))
			{
				return attempts.attempts;
			}
			return 0;
		}
		#endregion
		#region Select
		private IEnumerable<BlockData> selectBlockData(Predicate<BlockData> selectPredicate = null)
		{
			foreach (BlockData data in readFileData(BLOCKS_FILE, new BlockData()))
			{
				if (selectPredicate == null || selectPredicate(data))
					yield return data;
			}
		}
		private IEnumerable<ConfigData> selectConfigData(Predicate<ConfigData> selectPredicate = null)
		{
			foreach (ConfigData data in readFileData(CONFIGS_FILE, new ConfigData()))
			{
				if (selectPredicate == null || selectPredicate(data))
					yield return data;
			}
		}

		private IEnumerable<UserData> selectUsersData(Predicate<UserData> selectPredicate = null)
		{
			foreach (UserData data in readFileData(USERS_FILE, new UserData()))
			{
				if (selectPredicate == null || selectPredicate(data))
					yield return data;
			}
		}

		private IEnumerable<LoginAttemptsData> selectLoginAttempts(Predicate<LoginAttemptsData> selectPredicate = null)
		{
			foreach (LoginAttemptsData data in readFileData(ATTEMPTS_FILE, new LoginAttemptsData()))
			{
				if (selectPredicate == null || selectPredicate(data))
					yield return data;
			}
		}
		#endregion
		#region Update
		private void updateAttempts(
			Predicate<LoginAttemptsData> updatePredicate,
			Func<LoginAttemptsData, LoginAttemptsData> updateFunc
		)
		{
			updateLines(
				ATTEMPTS_FILE, new LoginAttemptsData(),
				a => updatePredicate((LoginAttemptsData)a),
				a => updateFunc((LoginAttemptsData)a)
			);
		}
		#endregion
		#region Delete
		private void deleteLoginAttempts(Predicate<LoginAttemptsData> deletePredicate)
		{
			deleteLines(ATTEMPTS_FILE, new LoginAttemptsData(), data => deletePredicate.Invoke((LoginAttemptsData)data));
		}
		#endregion
		#region CRUD
		private void createLine(string fileName, IFileData data)
		{
			using (var writer = new StreamWriter(fileName, true))
			{
				writer.WriteLine(data.ToLine());
			}
			if (fileName == LOGS_FILE)
			{
				DateTime now = DateTime.Now;
				if (DateTime.TryParse(GetConfig(LastArchiveDate), out DateTime lastArchiveDate) == true && 
					now.ToString("d").Equals(lastArchiveDate.ToString("d")))
					return;
				GzipLogs(SYSTEM_UUID);
			}
		}

		private IEnumerable<IFileData> readFileData(string fileName, IFileData type)
		{
			foreach(string line in readLines(fileName))
				yield return type.FromLine(line);
		}

		private IEnumerable<string> readLines(string fileName)
		{
			string line;
			using (var reader = File.OpenText(fileName))
			{
				while ((line = reader.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}

		private void updateLines(
			string fileName, IFileData type,
			Predicate<IFileData> updatePredicate,
			Func<IFileData, IFileData> updateFunc
		)
		{
			Action<IFileData, StreamWriter> updateDelegate = delegate (IFileData data, StreamWriter writer)
			{
				if (updatePredicate.Invoke(data))
				{
					IFileData updatedData = updateFunc(data);
					writer.WriteLine(updatedData.ToLine());
				}
				else
				{
					writer.WriteLine(data.ToLine());
				}
			};
			buildFilePipe(fileName, type, updateDelegate);
		}

		private void deleteLines(string fileName, IFileData type, Predicate<IFileData> deletePredicate)
		{
			Action<IFileData, StreamWriter> deleteDelegate = delegate (IFileData data, StreamWriter writer)
			{
				if (deletePredicate.Invoke(data) == false)
				{
					writer.WriteLine(data.ToLine());
				}
			};
			buildFilePipe(fileName, type, deleteDelegate);
		}
		#endregion
		#region Utils
		private void buildFilePipe(string fileName, IFileData type, Action<IFileData, StreamWriter> pipeAction)
		{
			string tempFile = Path.GetTempFileName();
			using (var writer = new StreamWriter(tempFile))
			{
				foreach (IFileData data in readFileData(fileName, type))
				{
					pipeAction?.Invoke(data, writer);
				}
			}
			File.Copy(tempFile, fileName, true);
			File.Delete(tempFile);
		}

		public string GzipLogs(Guid adminUuid)
		{
			if (IsAdmin(adminUuid) == false)
				return "У вас недостаточно прав!";
			if (Directory.Exists(ARCHIVE_DIR) == false)
			{
				Directory.CreateDirectory(ARCHIVE_DIR);
			}
			DateTime now = DateTime.Now;
			string archivePath = $"{ARCHIVE_DIR}\\" +now.ToString("yyyy-MM-dd_HH-mm") + "_logs.EventLogData.gz";
			if (File.Exists(archivePath))
			{
				return "Недавно уже проводилась архивация!";
			}
			using (FileStream logsFile = File.OpenRead(LOGS_FILE))
			using (GZipStream archiveStream = new GZipStream(File.Create(archivePath), CompressionMode.Compress, false))
			{
				logsFile.CopyTo(archiveStream);
			}
			File.Create(LOGS_FILE).Close();
			createLine(LOGS_FILE, new EventLogData(
					EventLogData.EventLogType.LogsArchived, adminUuid, getIp(),
					$"{(adminUuid == SYSTEM_UUID ? "Система выполнила" : $"Администратор {adminUuid} выполнил")} архивацию журнала событий."));

			SetConfig(LastArchiveDate, now.ToString(), SYSTEM_UUID, out string result, out bool denied);
			return "Архивация завершена.";
		}

		public IEnumerable<EventLogData> UnGzipLogs(Guid adminUuid, string archivePath)
		{
			if (IsAdmin(adminUuid) == false)
				yield break;

			string tempPath = Path.GetTempFileName();
			using (FileStream tempFile = File.OpenWrite(tempPath))
			using (GZipStream archiveStream = new GZipStream(File.OpenRead(archivePath), CompressionMode.Decompress, false))
			{
				archiveStream.CopyTo(tempFile);
			}
			foreach (EventLogData data in readFileData(tempPath, new EventLogData()))
			{
				yield return data;
			}
			File.Delete(tempPath);
		}
		#endregion
	}
}
