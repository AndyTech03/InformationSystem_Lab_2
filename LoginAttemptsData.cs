using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class LoginAttemptsData : IFileData
	{
		public string uuid {  get; private set; }
		public int attempts { get; private set; }

		public LoginAttemptsData() { }

		public LoginAttemptsData(string uuid, int attempts)
		{
			this.uuid = uuid;
			this.attempts = attempts;
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new LoginAttemptsData()
			{
				uuid = data[0],
				attempts = int.Parse(data[1]),
			};
		}

		public string ToLine()
		{
			return $"{uuid}\t{attempts}";
		}

		public void AddAttempt()
		{
			attempts++;
		}
	}
}
