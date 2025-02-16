using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem_Lab_2
{
	public interface IFileData
	{
		string ToLine();

		IFileData FromLine(string line);
	}
}
