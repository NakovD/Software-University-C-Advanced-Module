using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DefiningClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var carLines = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < carLines; i++)
            {
                var currentLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = currentLine[0];
                var carFuel = double.Parse(currentLine[1]);
                var carConsumption = double.Parse(currentLine[2]);
                var newCar = new Car() { Model = carModel, FuelAmount = carFuel, FuelConsumptionPerKilometer = carConsumption };
                cars.Add(newCar);
            }

            var command = Console.ReadLine();

            while (!command.Contains("End"))
            {
                var commandData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var carModel = commandData[1];
                var kmToTravel = double.Parse(commandData[2]);
                var neededCar = cars.Find(car => car.Model == carModel);
                neededCar.Travel(kmToTravel);
                command = Console.ReadLine();
            }

            var carsForPrinting = cars.Select(car => $"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");

            Console.WriteLine(string.Join(Environment.NewLine, carsForPrinting));
        }
    }
}
