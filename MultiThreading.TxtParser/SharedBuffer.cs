using MultiThreading.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser
{
	public class SharedBuffer
	{
		private readonly List<Person> people = new List<Person>();
		private int _numberOfOccupiedElements;
		private readonly object _locker = new();

		public void Put(Person person)
		{
			lock (_locker)
			{
				people.Add(person);
				_numberOfOccupiedElements++;
				Monitor.Pulse(_locker);
			}
		}

		public Person Get()
		{
			lock (_locker)
			{
				while (_numberOfOccupiedElements == 0)
				{
					_ = Monitor.Wait(_locker);
				}
				var person = people.FirstOrDefault();	
				people.Remove(person);
				_numberOfOccupiedElements--;
				Monitor.Pulse(_locker);
				return person;
			}
		}
	}
}
