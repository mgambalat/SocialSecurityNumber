using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static System.Console;

namespace SocialSecurityNumber
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string firstName, lastName, socialSecurityNumber;
            FetchInputData(args, out firstName, out lastName, out socialSecurityNumber);
            Console.Clear();

            string gender = GetGender(socialSecurityNumber);

            int age = CalculateAge(socialSecurityNumber);

            DateTime birthDate = CalculateBirthdate(socialSecurityNumber);

            string generation = GetGeneration(birthDate);

            PrintOut(firstName, lastName, socialSecurityNumber, gender, age, generation);
        }

        private static void PrintOut(string firstName, string lastName, string socialSecurityNumber, string gender, int age, string generation)
        {
            Console.WriteLine($"{"Name: ",-25}{firstName} {lastName}\n" +
                           $"{"Social Security Number:",-25}{socialSecurityNumber}\n" +
                           $"{"Gender:",-25}{gender}\n" +
                           $"{"Age:",-25}{age}\n" +
                           $"{"Generation:",-25}{generation}");
        }

        private static string GetGeneration(DateTime birthDate)
        {
            string generation = " ";
            const int XennialsBegin = 1977;
            const int XennialsEnds = 1983;
            bool activateXennial = birthDate.Year >= XennialsBegin && birthDate.Year <= XennialsEnds;
            bool isXennial = false;
            if (activateXennial)
            {
                Console.WriteLine("Did you play video games as a kid? (Y)es/(N)o");
                string input = Console.ReadLine();
                string key = input.ToUpper();
                bool xennialYes = key == "Y";
                if (xennialYes)
                {
                    generation = "Xennial";
                    isXennial = true;
                }

            }
            if (isXennial == false)
            {

                const int SilentGenerationEnds = 1945;
                const int BabyBoomersEnds = 1964;
                const int GenerationXEnds = 1979;
                const int MillennialsEnds = 1995;
                const int GenerationZEnds = 2010;

                switch (birthDate.Year <= SilentGenerationEnds ? "SilentGeneration" :
                        birthDate.Year <= BabyBoomersEnds ? "Babyboomer" :
                        birthDate.Year <= GenerationXEnds ? "GenerationX" :
                        birthDate.Year <= MillennialsEnds ? "Millennial" :
                        birthDate.Year <= GenerationZEnds ? "GenerationZ" : "GenerationAlpha")

                {
                    case "SilentGeneration":
                        generation = "Silent Generation";
                        break;

                    case "Babyboomer":
                        generation = "Babyboomer";
                        break;

                    case "GenerationX":
                        generation = "GenerationX";
                        break;

                    case "Millennial":
                        generation = "Millennial";
                        break;
                    case "GenerationZ":
                        generation = "GenerationZ";
                        break;

                    default:
                        generation = "GenerationAlpha";
                        break;
                }
            }

            return generation;
        }

        private static void FetchInputData(string[] args, out string firstName, out string lastName, out string socialSecurityNumber)
        {
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

                Console.Write("Social Security Number (YYYYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();
            }
        }

        private static int CalculateAge(string socialSecurityNumber) 
         {
            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }
            return age;
         }
        private static DateTime CalculateBirthdate(string socialSecurityNumber)
        {
            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            return birthDate;
        }
        private static string GetGender(string socialSecurityNumber)
        {
            string gender;
            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            gender = isFemale ? "Female" : "Male";
            return gender;
        }
    }
}

