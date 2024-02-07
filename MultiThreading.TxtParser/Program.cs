
using MultiThreading.TxtParser;

namespace MultiThreading.CreateTxtFile
{
	public class Program
	{
		private static readonly SharedBuffer buffer = new();
		private static readonly Producer producer = new(buffer);
		public static async Task Main()
		{
			var t1 = Task.Run(producer.Produce);
			//var t2 = Task.Run(consumer.Consume);

			//await Task.WhenAll(t1, t2);
		}
	}
}
