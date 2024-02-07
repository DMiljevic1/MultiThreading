using MultiThreading.TxtParser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser
{
	public class Producer
	{
		private readonly SharedBuffer _buffer;
		private const string filename = "";
		public Producer(SharedBuffer buffer)
		{
			_buffer = buffer;
		}
		public async Task Produce()
		{
			using (var reader = new StreamReader(filename))
			{
				while (!reader.EndOfStream)
				{
					var txtLine = await reader.ReadLineAsync();
					var person = TxtParserService.Parse(txtLine!);
					_buffer.Put(person);	
				}
			}
		}
	}
}
