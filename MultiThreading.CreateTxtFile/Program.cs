using System;
using System.IO;
using System.Threading.Tasks;

namespace MultiThreading.CreateTxtFile;

public static class Program
{
	private const int NumberOfRows = 100_000_000;

	private static readonly Random s_random = new();

	public static async Task Main()
	{
		var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
		var outputFilePath = Path.Combine(userFolder, @"Downloads\data.txt");               //write your path to your data.txt file

		using var outputFileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate);
		using var streamWriter = new StreamWriter(outputFileStream);

		await streamWriter.WriteLineAsync("Type;OIB;Name;Gender;DateOfBirth;AvgGrade;Paycheck");

		for (var i = 0; i < NumberOfRows; i++)
		{
			var personRandomNumber = s_random.Next(0, 11);

			var row = personRandomNumber switch
			{
				0 => GetInvalidRowString(),
				< 6 => GetProfessorRowString(i),
				_ => GetStudentRowString(i)
			};
			await streamWriter.WriteLineAsync(row);
		}
	}

	private static string GetProfessorRowString(int rowNumber)
	{
		var isProfessorErrorRow = s_random.Next(0, 11) == 5;

		return isProfessorErrorRow
			? $"Professor;error;error;error;error;error;error"
			: $"Professor;{rowNumber * 3478931L % 100000000};Name{rowNumber};{(rowNumber % 2 == 0 ? "Male" : "Female")};11/1/1999;;{rowNumber % 15 * 1000}";
	}

	private static string GetStudentRowString(int rowNumber)
	{
		var isStudentErrorRow = s_random.Next(0, 11) == 5;

		return isStudentErrorRow
			? $"Student;error;error;error;error;error;error"
			: $"Student;{rowNumber * 3478931L % 100000000};Name{rowNumber};{(rowNumber % 2 == 0 ? "Male" : "Female")};11/1/1999;{rowNumber % 5};";
	}

	private static string GetInvalidRowString()
	{
		return $"error;error;error;error;error;error;error";
	}
}