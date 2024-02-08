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
		private const int NumberOfRows = 100_000_000;

		public Consumer(SharedBuffer buffer)
		{
			_buffer = buffer;
		}
		public async Task Consume()
		{
			for(var i = 0; i < NumberOfRows; i++)
			{
				var person = _buffer.Get();
				await TxtParserService.ParseToTxt(person);
			}
		}
	}
}
