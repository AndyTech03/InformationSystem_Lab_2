using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class LoginAttempts
	{
		public string uuid {  get; private set; }
		public int attempts { get; private set; }

		public static LoginAttempts FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new LoginAttempts()
			{
				uuid = data[0],
				attempts = int.Parse(data[1]),
			};
		}
	}
}
