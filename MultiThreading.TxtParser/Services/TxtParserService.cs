﻿using MultiThreading.DomainModels.Models;
using MultiThreading.TxtParser.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser.Services
{
	public class TxtParserService
	{
		private const string Student = "Student";
		private const string Professor = "Professor";

		public static Person Parse(string txtLine)
		{
			var splittedRow = txtLine.Split(";");
			var oib = splittedRow[1];
			var name = splittedRow[2];
			var gender = Converter.ConvertStringToGender(splittedRow[3]);
			var dateOfBirth = Converter.ConvertStringToDateOnly(splittedRow[4]);
			if (splittedRow[0].Equals(Student))
			{
				var averageGrade = Converter.ConvertStringToDouble(splittedRow[5]);
				if (!gender.HasValue || !dateOfBirth.HasValue || !averageGrade.HasValue)
					return null!;
				return new Student(oib, name, gender.Value, dateOfBirth.Value, averageGrade.Value);
			}
			else if (splittedRow[0].Equals(Professor))
			{
				var paycheck = Converter.ConvertStringToDecimal(splittedRow[6]);
				if (!gender.HasValue || !dateOfBirth.HasValue || !paycheck.HasValue)
					return null!;
				return new Professor(oib, name, gender.Value, dateOfBirth.Value, paycheck.Value);
			}
			return null!;
		}
	}
}
