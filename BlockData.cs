using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public class BlockData : IFileData
	{
		public Guid uuid {  get; private set; }
		public string reason { get; private set; }
		public DateTime blockedAt { get; private set; }

		public BlockData() { }

		public BlockData(Guid uuid, string reason)
		{
			this.uuid = uuid;
			this.reason = reason;
			blockedAt = DateTime.Now;
		}

		public IFileData FromLine(string line)
		{
			string[] data = line.Split('\t');
			return new BlockData {
				uuid = Guid.Parse(data[0]),
				reason = data[1],
				blockedAt = DateTime.Parse(data[2]),
			};
		}

		public string ToLine()
		{
			return $"{uuid}\t{reason}\t{blockedAt}";
		}
	}
}
