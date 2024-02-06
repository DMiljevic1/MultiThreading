using MultiThreading.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.DomainModels.Models
{
	public class Student : Person
	{
		public double AverageGrade { get; set; }

		public Student(string oib, string name, Gender gender, DateOnly dateOfBirth, double averageGrade) : base(oib, name, gender, dateOfBirth)
		{
			AverageGrade = averageGrade;
		}

		public Student() { }
	}
}
