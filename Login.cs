using System;
namespace PetrolStationCore_v2
{
    public class Login
    {
        public static bool correctPin;
        readonly string password = System.IO.File.ReadAllText(@"../../../login.txt");

        public Login()
        {
            Console.ResetColor();
            Console.WriteLine("Enter pin to continue or type 'quit' to close the program");
            string login = Console.ReadLine();

            if (login.ToLower() == "quit")
            {
                Console.WriteLine("\n");
                Console.WriteLine("Closing application...");
                System.Environment.Exit(1);
            }


            if (login == password)
            {
                correctPin = true;
            }

            else
            {
                correctPin = false;
            }

            if (!correctPin)
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n");
                    Console.WriteLine("Incorrect pin, please try again... or type 'quit' to close the program");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                    {
                        Console.ResetColor();
                        Console.WriteLine("\n");
                        Console.WriteLine("Closing application...");
                        System.Environment.Exit(1);
                    }

                    else if (input == password)
                    {
                        Console.ResetColor();
                        correctPin = true;
                    }

                } while (!correctPin);
            }

            if (correctPin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n");
                Console.WriteLine("Log in successful");
                Console.ResetColor();
            }
        }
    }
}
