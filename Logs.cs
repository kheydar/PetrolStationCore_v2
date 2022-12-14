using System;
using System.IO;
using System.Reflection.Metadata;

namespace PetrolStationCore_v2
{
	public class Logs
	{
        public Logs()
		{
            Program.running = false;
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("Closing application...");

            string time = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
            string filePath = "../../../DailyReports/DailyReport_" + time + ".txt";
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Directory.Create();
            
            string content = "Daily report: \n\n" +
            $"Litres dispensed: {Program.litresDispensed} \n" +
            $"Fuel cost: £ {Program.cost}\n" +
            $"1%: £ {Program.commision}\n" +
            $"Vehicles serviced: {Program.carsServed} \n" +
            $"Left early {Program.carsLeftEarly}\n";

            System.IO.File.WriteAllText(file.FullName, content);
        }
	}
}

