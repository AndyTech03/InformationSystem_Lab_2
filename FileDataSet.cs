using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_Lab_2
{
	public class FileDataSet
	{
		private const string USERS_FILE = "users.UserData";
		private const string ATTEMPTS_FILE = "attempts.LoginAttemptsData";
		private const string CONFIGS_FILE = "configx.ConfigsData";
		private const string BLOCKS_FILE = "blocks.BlockData";
		private const string LOGS_FILE = "logs.EventLogData";
		private const string ADMINS_FILE = "admins.Guid";

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
				if (user.password == password)
				{
					result = true;
					uuid = user.uuid;
					break;
				}
			}
			blocked = getUuidBlock(uuid);
			attempts = getLoginAttemptsCount(uuid);

			if (uuid == Guid.Empty)
				return Guid.Empty;
			return uuid;
		}

		public void FirstLoginAttempt(Guid uuid)
		{
			if (uuid == null)
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

		public void LogOut(Guid uuid)
		{
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserLogOut, uuid, getIp(),
				"Пользователь самостоятельно вышел из системы."));
		}

		public bool IsAdmin(Guid uuid)
		{
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

		public void BlockIfNot(Guid uuid, string reason)
		{
			if (uuid == Guid.Empty)
				return;
			foreach(BlockData block in selectBlockData(b => b.uuid == uuid && b.reason == reason))
				return;
			createLine(BLOCKS_FILE, new BlockData(uuid, reason));
			createLine(LOGS_FILE, new EventLogData(
				EventLogData.EventLogType.UserBlocked, uuid, getIp(), reason));
		}

		#region Get
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

		public string GetConfig(string configName)
		{
			Dictionary<string, string> defaultConfigs = new Dictionary<string, string>()
			{
				{ "MaxLoginAttempts", "3"}
			};

			if (defaultConfigs.ContainsKey(configName) == false)
			{
				throw new KeyNotFoundException($"'{configName}' - несуществующее имя конфига!");
			}
			foreach (ConfigData config in selectConfigData(c => c.name == configName))
			{
				return config.data;
			}
			return defaultConfigs[configName];
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
		#endregion
	}
}
