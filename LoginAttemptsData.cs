﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class LoginAttemptsData : IFileData
	{
		public Guid uuid {  get; private set; }
		public int attempts { get; private set; }

		public LoginAttemptsData() { }

		public LoginAttemptsData(Guid uuid)
		{
			this.uuid = uuid;
			this.attempts = 1;
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new LoginAttemptsData
			{
				uuid = Guid.Parse(data[0]),
				attempts = int.Parse(data[1]),
			};
		}

		public LoginAttemptsData AddAttempt()
		{
			attempts++;
			return this;
		}

		public string ToLine()
		{
			return $"{uuid}\t{attempts}";
		}
	}
}
