using MultiThreading.TxtParser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser
{
	public class Consumer
	{
		private readonly SharedBuffer _buffer;
		public Consumer(SharedBuffer buffer)
		{
			_buffer = buffer;
		}
		public async Task Consume()
		{
			var person = _buffer.Get();
			await TxtParserService.ParseToTxt(person);
		}
	}
}
