using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarSalesman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            var enginesCount = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            ReadEngines(enginesCount, engines);

            var carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            ReadCars(carsCount, cars, engines);

            var carsReadyToPrint = cars.Select(car => car.ToString());

            Console.WriteLine(string.Join(Environment.NewLine, carsReadyToPrint));
        }
        public static void ReadEngines(int enginesRemaining, List<Engine> engines)
        {
            if (enginesRemaining == 0) return;
            var engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var engineModel = engineData[0];
            var enginePower = int.Parse(engineData[1]);
            var newEngine = new Engine(engineModel, enginePower);
            if (engineData.Length == 3)
            {
                var isNumber = int.TryParse(engineData[2], out int displacement);
                if (isNumber) newEngine.Displacement = displacement;
                else newEngine.Efficiency = engineData[2];
            }
            if (engineData.Length == 4)
            {
                newEngine.Displacement = int.Parse(engineData[2]);
                newEngine.Efficiency = engineData[3];
            }

            engines.Add(newEngine);
            enginesRemaining--;

            ReadEngines(enginesRemaining, engines);
        }

        public static void ReadCars(int carsRemaining, List<Car> cars, List<Engine> engines)
        {
            if (carsRemaining == 0) return;

            var carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var carModel = carData[0];
            var carEngine = carData[1];
            var neededEngine = engines.Find(engine => engine.Model == carEngine);
            var newCar = new Car(carModel, neededEngine);
            if (carData.Length == 3)
            {
                var isNumber = int.TryParse(carData[2], out int weight);
                if (isNumber) newCar.Weight = weight;
                else newCar.Color = carData[2];
            }
            if (carData.Length == 4)
            {
                newCar.Weight = int.Parse(carData[2]);
                newCar.Color = carData[3];
            }

            cars.Add(newCar);
            carsRemaining--;
            ReadCars(carsRemaining, cars, engines);
        }
    }
}
