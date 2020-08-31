using System;
using System.Globalization;
using static System.Console;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Social Security Number (YYMMDD-XXXX): ");

            string socialSecurityNumber = ReadLine();
            string gender;

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 6), "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }

            WriteLine($"{gender}, {age}");
        }
    }
}
