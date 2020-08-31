using System;
using System.Globalization;
using static System.Console;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string socialSecurityNumber;


            if (args.Length > 0)
            {
                socialSecurityNumber = args[0];

            }
            else 
            {
                Write("Social Security Number (YYMMDD-XXXX): ");

                socialSecurityNumber = ReadLine();
            }

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
