using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class ConfigData : IFileData
	{
		public string name { get; private set; }
		public string data { get; private set; }

		public ConfigData() { }
		
		public ConfigData(string name, string data)
		{
			this.name = name;
			this.data = data;
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new ConfigData(data[0], data[1]);
		}

		public string ToLine()
		{
			return $"{name}\t{data}";
		}
	}
}
