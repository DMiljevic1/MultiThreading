using MultiThreading.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.DomainModels.Models
{
	public abstract class Person
	{
		public string? Oib { get; set; }
		public string? Name { get; set; }
		public Gender Gender { get; set; }
		public DateOnly DateOfBirth { get; set; }

		protected Person(string oib, string name, Gender gender, DateOnly dateOfBirth)
		{
			Oib = oib;
			Name = name;
			Gender = gender;
			DateOfBirth = dateOfBirth;
		}

		protected Person() { }
	}
}
