using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var tires = new List<Tire[]>();
            ReadTires(tires);
            var engines = new List<Engine>();
            ReadEngines(engines);
            var cars = new List<Car>();
            ReadCars(cars, engines, tires);

            var specialCars = cars.Where(car => 
                car.Year >= 2017 
                && car.Engine.HorsePower > 330 
                && car.Tires.Sum(tire => tire.Pressure) > 9 
                && car.Tires.Sum(tire => tire.Pressure) < 10);

            var sb = new StringBuilder();

            foreach (var car in specialCars)
            {
                car.Drive(2);
                sb.AppendLine($"Make: {car.Make}");
                sb.AppendLine($"Model: {car.Model}");
                sb.AppendLine($"Year: {car.Year}");
                sb.AppendLine($"HorsePowers: {car.Engine.HorsePower}");
                sb.AppendLine($"FuelQuantity: {car.FuelQuantity}");
            }

            Console.WriteLine(sb.ToString());
        }

        public static void ReadTires(List<Tire[]> tires)
        {
            var input = Console.ReadLine();

            if (input.Contains("No more tires")) return;

            var tiresInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var tiresSet = new Tire[4];

            var tiresSetIndex = 0;

            for (int i = 0; i < tiresInfo.Length; i += 2)
            {
                var tireYear = int.Parse(tiresInfo[i]);

                var pressure = double.Parse(tiresInfo[i + 1]);

                var newTire = new Tire(tireYear, pressure);

                tiresSet[tiresSetIndex] = newTire;

                tiresSetIndex++;
            }

            tires.Add(tiresSet);
            ReadTires(tires);
        }

        public static void ReadEngines(List<Engine> engines)
        {
            var input = Console.ReadLine();

            if (input.Contains("Engines done")) return;

            var engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var enginePower = int.Parse(engineInfo[0]);

            var engineCapacity = double.Parse(engineInfo[1]);

            var newEngine = new Engine(enginePower, engineCapacity);

            engines.Add(newEngine);

            ReadEngines(engines);
        }

        public static void ReadCars(List<Car> cars, List<Engine> engines, List<Tire[]> tires)
        {
            var input = Console.ReadLine();

            if (input.Contains("Show special")) return;

            var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var carMake = carInfo[0];

            var carModel = carInfo[1];

            var carYear = int.Parse(carInfo[2]);

            var carFuelQuantity = double.Parse(carInfo[3]);

            var carFuelConsumption = double.Parse(carInfo[4]) / 10;

            var carEngineIndex = int.Parse(carInfo[5]);

            var carTiresIndex = int.Parse(carInfo[6]);

            var engine = engines.ElementAtOrDefault(carEngineIndex);

            var neededTires = tires.ElementAtOrDefault(carTiresIndex);

            var newCar = new Car(carMake, carModel, carYear, carFuelQuantity, carFuelConsumption, engine, neededTires);

            cars.Add(newCar);

            ReadCars(cars, engines, tires);
        }
    }
}

