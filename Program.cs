using System;
using System.Timers;
using System.Threading;
using System.IO;

namespace PetrolStationCore_v2
{
    public class Program
    {
        public static double litresDispensed = 0;
        public static int avaliablePumps = 9;
        public static int carsCreated = 0;
        public static int carsServed = 0;
        public static bool running = true;
        public static bool correctPin;
        public static int carsQueue = 0;
        public static int carsLeftEarly = 0;
        public static readonly double fuelCost = 1.5;
        public static double cost;
        public static double commision;

        public static System.Timers.Timer display;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;        
            Console.WriteLine("Welcome to Broken Petrol Ltd");
            Console.WriteLine("\n\n");

            var security = new Login();
            //var vehicle_timer = new VehicleTimer();
            var refuel = new Refuel();
            

            if (Login.correctPin)
            {
                    
                do
                {
                    while (avaliablePumps==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Waiting for a free pump...");
                        Thread.Sleep(2000);
                        Console.WriteLine("\n");
                    }

                    Console.ResetColor();
                    var vehicle_timer = new VehicleTimer();
                    //Console.WriteLine("New vehicle arrived, please select pump or type 'quit' to close the program");
                    string userInput = Console.ReadLine();

                    if (userInput.ToLower() == "quit")
                    {
                        var Log = new Logs();
                    }
                        
                    avaliablePumps -= 1;

                    if (running)
                    {
                        //Display();
                        Console.WriteLine("\n");
                        Console.WriteLine($"Vechile assigned to pump {userInput}, {avaliablePumps} pumps avaliable");
                        Console.WriteLine("\n");
                        Console.WriteLine(new string('#', 80));

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        var output =
                            $"Queue: {carsQueue} \n" +
                            //$"Cars created: {carsCreated} \n" +
                            $"Litres dispensed: {litresDispensed} \n" +
                            $"Fuel cost: £ {cost}\n" +
                            $"1%: £ {commision}\n" +
                            $"Vehicles serviced: {carsServed} \n" +
                            $"Avaliable pumps: {avaliablePumps} \n" +
                            $"Left early {carsLeftEarly}\n"
                            ;

                        Console.WriteLine(output);
                    }
                } while (running);
            }
        }

        
        private static void Display()
        {
            display = new System.Timers.Timer(1000);
            display.Enabled = true;
            display.AutoReset = true;
            display.Elapsed += DisplayTimer;
            display.Start();
        }


        private static void DisplayTimer(Object source, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                $"Queue: {carsQueue} \n" +
                //$"Cars created: {carsCreated} \n" +
                $"Litres dispensed: {litresDispensed} \n" +
                $"Fuel cost: £ {cost}\n" +
                $"1%: £ {commision}\n" +
                $"Vehicles serviced: {carsServed} \n" +
                $"Avaliable pumps: {avaliablePumps} \n" +
                $"Left early {carsLeftEarly}"
                );
        }
    }
}



