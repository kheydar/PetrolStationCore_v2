using System;
using System.Timers;

namespace PetrolStationCore_v2
{
	public class Refuel
	{
        public static System.Timers.Timer refuel;

        public Refuel()
		{
            Refuel();

            static void Refuel()
            {
                Random random = new Random();
                int refuelTime = random.Next(3000, 5000);
                refuel = new System.Timers.Timer();
                refuel.Interval = refuelTime;
                refuel.Enabled = true;
                refuel.AutoReset = false;
                refuel.Elapsed += RefuelTimer;
                refuel.Start();
            }

            static void RefuelTimer(Object source, ElapsedEventArgs e)
            {
                Random random = new Random();
                int refuelTime = random.Next(3000, 5000);
                refuel.Interval = refuelTime;

                double fuelDispensed = 1.5 * (refuelTime / 1000);
                Program.litresDispensed += fuelDispensed;
                Program.cost = Program.litresDispensed * Program.fuelCost;
                Program.commision = Program.cost * 0.01;
                Program.carsServed += 1;

                if (Program.avaliablePumps < 9)
                {
                    Program.avaliablePumps += 1;
                }

                if (Program.carsQueue > 0)
                {
                    Program.carsQueue -= 1;
                }
            }
        }
	}
}

