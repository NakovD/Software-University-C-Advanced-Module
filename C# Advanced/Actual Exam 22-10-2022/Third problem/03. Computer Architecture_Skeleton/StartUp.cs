using System;
using System.Globalization;
using System.Threading;

namespace ComputerArchitecture
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            // Initialize the repository
            Computer computer = new Computer("Gaming Serioux", 4);

            // Initialize entity
            CPU cpu = new CPU("AMD Ryzen 5", 6, 3.7);

            // Print CPU
            Console.WriteLine(cpu);
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz

            computer.Add(cpu);

            // Remove CPU
            Console.WriteLine(computer.Remove("Intel Core i5"));

            CPU secondCPU = new CPU("Intel Core i7", 8, 4);
            CPU thirdCPU = new CPU("Intel Core i5", 8, 3.9);

            // Add CPU
            computer.Add(secondCPU);
            computer.Add(thirdCPU);

            CPU mostPowerful = computer.MostPowerful();
            Console.WriteLine(mostPowerful);

            CPU receivedCPU = computer.GetCPU("Intel Core i5");
            Console.WriteLine(receivedCPU);

            Console.WriteLine(computer.Count);

            Console.WriteLine(computer.Remove("Intel Core i5"));

            Console.WriteLine(computer.Report());
        }
    }
}
