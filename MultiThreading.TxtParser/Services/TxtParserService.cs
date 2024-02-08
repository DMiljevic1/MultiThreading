using MultiThreading.DomainModels.Models;
using MultiThreading.TxtParser.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser.Services
{
	public class TxtParserService
	{
		private const string Student = "Student";
		private const string Professor = "Professor";
		private const string errorFilePath = "C:\\Users\\dujem\\OneDrive\\Documents\\error-rows.txt";
		private const string passedStudentsFilePath = "C:\\Users\\dujem\\OneDrive\\Documents\\passed-students.txt";
		private const string failedStudentsFilePath = "C:\\Users\\dujem\\OneDrive\\Documents\\failed-students.txt";
		private const string professorsFilePath = "C:\\Users\\dujem\\OneDrive\\Documents\\professors.txt";

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
					return new Student(oib, name, gender.GetValueOrDefault(), dateOfBirth.GetValueOrDefault(), true, averageGrade.GetValueOrDefault());
				return new Student(oib, name, gender.Value, dateOfBirth.Value, false, averageGrade.Value);
			}
			else if (splittedRow[0].Equals(Professor))
			{
				var paycheck = Converter.ConvertStringToDecimal(splittedRow[6]);
				if (!gender.HasValue || !dateOfBirth.HasValue || !paycheck.HasValue)
					return new Professor(oib, name, gender.GetValueOrDefault(), dateOfBirth.GetValueOrDefault(), true, paycheck.GetValueOrDefault());
				return new Professor(oib, name, gender.Value, dateOfBirth.Value, false, paycheck.Value);
			}
			return null;
		}

		public static async Task ParseToTxt(Person person)
		{
			string txtLine = "";
			if (person == null)
			{
				txtLine = "error;error;error;error;error;error;error";
				Console.ForegroundColor = ConsoleColor.Red;
                await TxtFileService.Write(txtLine, errorFilePath);
			}
			else if(person.Error)
			{
				string personType = person is Student ? Student : Professor;
				txtLine = personType + ";error;error;error;error;error;error";
				Console.ForegroundColor = ConsoleColor.Red;
				await TxtFileService.Write(txtLine, errorFilePath);
			}
			else if(person is Student)
			{
				var student = (Student)person;
				txtLine = Student + student.Oib! + ";" + student.Name + ";" + student.Gender + ";" + student.DateOfBirth + ";" + student.AverageGrade;
				if (student.AverageGrade > 1)
				{
					await TxtFileService.Write(txtLine, passedStudentsFilePath);
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					await TxtFileService.Write(txtLine, failedStudentsFilePath);
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
			}
			else if(person is Professor)
			{
				var professor = (Professor)person;
				txtLine = Professor + professor.Oib! + ";" + professor.Name + ";" + professor.Gender + ";" + professor.DateOfBirth + ";" + professor.Paycheck;
				await TxtFileService.Write(txtLine, professorsFilePath);
				Console.ForegroundColor = ConsoleColor.Blue;
			}
			await Console.Out.WriteLineAsync(txtLine);
		}
	}
}
