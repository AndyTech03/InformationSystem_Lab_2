using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class FileDataSet
	{
		private const string USERS_FILE = "users.UserData";
		private const string ATTEMPTS_FILE = "attempts.LoginAttemptsData";
		private const string CONFIGS_FILE = "configx.ConfigsData";
		public FileDataSet()
		{
			foreach (string file in new string[] { USERS_FILE, ATTEMPTS_FILE, CONFIGS_FILE })
			{
				if (File.Exists(file) == false)
				{
					File.Create(file).Close();
				}
			}
		}

		public bool VerifyPassword(string login, string password)
		{
			foreach (UserData user in selectUsersData())
			{
				if (user.login == login)
				{
					if (user.password == password)
						return true;
					else
						return false;
				}
			}
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

		public int GetLoginAttempts(string login)
		{
			return getLoginAttemptsCount(login);
		}

		public void FirstLoginAttempt(string login)
		{
			string uuid = getUserUuid(login);
			if (uuid == null)
				return;
			createLine(ATTEMPTS_FILE, new LoginAttemptsData(uuid, 1));
		}

		public void AddLoginAttempt(string login)
		{
			string uuid = getUserUuid(login);
			if (uuid == null)
				return;
			updateLines(
				ATTEMPTS_FILE, new LoginAttemptsData(), 
				a => ((LoginAttemptsData)a).uuid == uuid,
				delegate (IFileData data)
				{
					LoginAttemptsData attempts = (LoginAttemptsData)data;
					attempts.AddAttempt();
					return attempts;
				}
			);
		}

		public string Login(string login, string password)
		{
			string uuid = null;
			foreach (UserData user in selectUsersData(u => u.login == login)) 
			{
				if (user.password == password)
					uuid = user.uuid;
				break;
			}
			if (uuid == null)
				return null;

			deleteLoginAttempts(a => a.uuid == uuid);

			return uuid;
		}

		public bool TryRegister(string login, string password)
		{
			string uuid = getUserUuid(login);
			if (uuid != null)
				return false;

			createLine(USERS_FILE, new UserData(login, password));

			return true;
		}

		private string getUserUuid(string login)
		{
			foreach (UserData user in selectUsersData(u => u.login == login))
			{
				return user.uuid;
			}
			return null;
		}

		private int getLoginAttemptsCount(string login)
		{
			UserData searchingUser = null;
			foreach (UserData user in selectUsersData(u => u.login == login))
			{
				searchingUser = user;
				break;
			}
			if (searchingUser == null)
				return 0;
			foreach (LoginAttemptsData attempts in selectLoginAttempts(a => a.uuid == searchingUser.uuid))
			{
				return attempts.attempts;
			}
			return 0;
		}

		#region Select
		private IEnumerable<ConfigData> selectConfigData(Predicate<ConfigData> selectPredicate = null)
		{
			foreach (ConfigData config in readLines(CONFIGS_FILE, new ConfigData()))
			{
				if (selectPredicate == null || selectPredicate(config))
					yield return config;
			}
		}

		private IEnumerable<UserData> selectUsersData(Predicate<UserData> selectPredicate = null)
		{
			foreach (UserData user in readLines(USERS_FILE, new UserData()))
			{
				if (selectPredicate == null || selectPredicate(user))
					yield return user;
			}
		}

		private IEnumerable<LoginAttemptsData> selectLoginAttempts(Predicate<LoginAttemptsData> selectPredicate = null)
		{
			foreach (LoginAttemptsData attempts in readLines(ATTEMPTS_FILE, new LoginAttemptsData()))
			{
				if (selectPredicate == null || selectPredicate(attempts))
					yield return attempts;
			}
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

		private IEnumerable<IFileData> readLines(string fileName, IFileData type)
		{
			string line;
			using (var reader = File.OpenText(fileName))
			{
				while ((line = reader.ReadLine()) != null)
				{
					yield return type.FromLine(line);
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
				foreach (IFileData data in readLines(fileName, type))
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
