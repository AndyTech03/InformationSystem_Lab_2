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
		public Predicate<string> validator { get; private set; }
		public string note { get; private set; }

		public ConfigData() { }
		
		public ConfigData(string name, string data, Predicate<string> validator, string note)
		{
			this.name = name;
			this.data = data;
			this.validator = validator;
			this.note = note;
		}

		public bool SetData(string value)
		{
			if (value == data)
				return false;
			if (validator.Invoke(value))
			{
				data = value;
				return true;
			}
			return false;
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new ConfigData{
				name = data[0], 
				data = data[1],
			};
		}

		public string ToLine()
		{
			return $"{name}\t{data}";
		}
	}
}
