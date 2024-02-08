using MultiThreading.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading.TxtParser.Converters
{
	public class Converter
	{
		public static Gender? ConvertStringToGender(string value)
		{
			if (Enum.TryParse<Gender>(value, out Gender gender))
				return gender;
			return null;
		}

		public static DateOnly? ConvertStringToDateOnly(string value)
		{
			if (DateOnly.TryParse(value, out DateOnly dateOnly))
				return dateOnly;
			return null;
		}

		public static decimal? ConvertStringToDecimal(string value)
		{
			try
			{
				return decimal.Parse(value, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static double? ConvertStringToDouble(string value)
		{
			try
			{
				return double.Parse(value, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
