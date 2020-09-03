using System;
using System.Globalization;
using static System.Console;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;
            

            if (args.Length > 0)
            {
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];

            }
            else 
            {
                Console.WriteLine("Please Enter:");

                Console.Write("Firstname: ");
                firstName = Console.ReadLine();

                Console.Write("Lastname: ");
                lastName = Console.ReadLine();
                    
                Console.Write("Social Security Number (YYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();
            }
            Console.Clear();

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
            string generation = "Non-Millennial";
            bool millennialControll = birthDate.Year >= 1981 && birthDate.Year <=1996 && age <=100;
            if (millennialControll)
            {
                generation = "Millenial";
            }

           Console.WriteLine($"{"Name: ", -25}{firstName} {lastName}\n" + 
               $"{"Social Security Number:", -25}{socialSecurityNumber}\n" +
               $"{"Gender:", -25}{gender}\n" +
               $"{"Age:", -25}{age}\n" +
               $"{"Generation:", -25}{generation}");
        }
    }
}
