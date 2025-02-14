using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class UserData
	{
		public string uuid { get; private set; }
		public string login { get; private set; }
		public string password { get; private set; }

		public static UserData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new UserData { 
				uuid = data[0],
				login = data[1],
				password = data[2],
			};
		}
	}
}
