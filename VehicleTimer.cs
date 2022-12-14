using System;
using System.Timers;

namespace PetrolStationCore_v2
{
	public class VehicleTimer
	{
        private static System.Timers.Timer createVechile;

        public VehicleTimer()
		{
            VechileTimer();

            static void VechileTimer()
            {
                Random random = new Random();
                int newVehicle = random.Next(1500, 2200);

                createVechile = new System.Timers.Timer();
                createVechile.Interval = newVehicle;
                createVechile.Enabled = true;
                createVechile.AutoReset = false;
                createVechile.Elapsed += vehicletimer;
                createVechile.Start();
            }

            static void vehicletimer(Object source, ElapsedEventArgs e)
            {
                Random random = new Random();
                int newVehicle = random.Next(1500, 2200);
                createVechile.Interval = newVehicle;
                Console.WriteLine($"New vehicle arrived {newVehicle}, please select pump or type 'quit' to close the program");

                if (Program.carsQueue > 5)
                {
                    Program.carsCreated += 1;
                    Program.carsLeftEarly += 1;
                }

                if (Program.avaliablePumps == 0)
                {
                    Program.carsCreated += 1;
                    Program.carsQueue += 1;
                }

                else
                {
                    Program.carsCreated += 1;
                    Program.carsQueue += 1;
                }
            }
        }
	}
}

