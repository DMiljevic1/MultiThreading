
using MultiThreading.TxtParser;
using System.Diagnostics;

namespace MultiThreading.CreateTxtFile
{
	public class Program
	{
		private static readonly SharedBuffer buffer = new();
		private static readonly Producer producer = new(buffer);
		private static readonly Consumer consumer = new(buffer);
		public static async Task Main()
		{
			var watch = Stopwatch.StartNew();
			var t1 = Task.Run(producer.Produce);
			var t2 = Task.Run(consumer.Consume);

			await Task.WhenAll(t1, t2);
			watch.Stop();
			Console.WriteLine($"The Execution time of the program is {watch.ElapsedMilliseconds}ms");
		}
	}
}
