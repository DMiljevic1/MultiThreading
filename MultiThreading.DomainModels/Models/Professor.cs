using MultiThreading.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.DomainModels.Models
{
	public class Professor : Person
	{
		public decimal Paycheck { get; set; }
		public Professor(string oib, string name, Gender gender, DateOnly dateOfBirth, decimal paycheck) : base(oib, name, gender, dateOfBirth)
		{
			Paycheck = paycheck;
		}

		public Professor() { }
	}
}
