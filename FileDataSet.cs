using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class FileDataSet
	{
		public bool VerifyPassword(string login, string password)
		{
			foreach (UserData user in getUsersData())
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

		public int GetConfig(string configName)
		{
			throw new NotImplementedException();
		}

		public int GetLoginAttempts(string login)
		{
			return getUserAttempts(login);
		}

		public void AddLoginAttempt(string login)
		{
			throw new NotImplementedException();
		}

		public string Login(string login, string password)
		{
			string uuid = null;
			foreach (UserData user in getUsersData()) 
			{
				if (user.login == login)
				{
					if (user.password == password)
						uuid = user.uuid;
					break;
				}
			}
			if (uuid == null)
				return null;

			return uuid;
		}

		public bool TryRegister(string login, string password)
		{
			throw new NotImplementedException();
		}

		private int getUserAttempts(string login)
		{
			foreach (UserData user in getUsersData())
			{
				if (user.login == login)
				{
					foreach(LoginAttempts attempts in getLoginAttempts())
					{
						if (attempts.uuid == user.uuid)
						{
							return attempts.attempts;
						}
					}
					break;
				}
			}
			return 0;
		}

		private IEnumerable<UserData> getUsersData()
		{
			string line;
			using (var reader = File.OpenText("users.UserData"))
			{
				while ((line = reader.ReadLine()) != null)
				{
					UserData user = UserData.FromLine(line);
					yield return user;
				}
			}
		}

		private IEnumerable<LoginAttempts> getLoginAttempts()
		{
			string line;
			using (var reader = File.OpenText("attempts.LoginAttempts"))
			{
				while ((line = reader.ReadLine()) != null)
				{
					LoginAttempts attempts = LoginAttempts.FromLine(line);
					yield return attempts;
				}
			}
		}
	}
}
