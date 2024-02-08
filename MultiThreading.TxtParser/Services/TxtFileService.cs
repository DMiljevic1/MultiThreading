using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser.Services
{
	public class TxtFileService
	{
		public static async Task Write(string txtLine, string filePath)
		{
			using (var writer = new StreamWriter(filePath, true))
			{
				await writer.WriteLineAsync(txtLine);
			}
		}
	}
}
