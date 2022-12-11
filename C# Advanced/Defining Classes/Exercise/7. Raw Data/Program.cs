using DefiningClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _7._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var carsCount = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            ReadCars(carsCount, cars);
            var filterCriteria = Console.ReadLine();

            List<string> filteredCars;

            if (filterCriteria.Contains("fragile"))
            {
                filteredCars = cars
                    .Where(car => car.Tires.Any(tire => tire.Pressure < 1))
                    .Select(car => car.Model)
                    .ToList();
            }
            else
            {
                filteredCars = cars
                    .Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    .Select(car => car.Model)
                    .ToList();
            }

            Console.Write(String.Join(Environment.NewLine, filteredCars));
        }

        static void ReadCars(int carsRemaining, List<Car> cars)
        {

            if (carsRemaining == 0) return;
            var carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (carData.Length < 13) { Console.WriteLine("Not enough parameters!"); return; }
            var carModel = carData[0];
            var carEngine = GetCarEngine(carData.Skip(1).Take(2).ToArray());
            var carCargo = GetCarCargo(carData.Skip(3).Take(2).ToArray());
            var carTires = GetCarTires(carData.Skip(5).Take(8).ToArray());
            var newCar = new Car(carModel, carEngine, carCargo, carTires.ToArray());
            carsRemaining--;
            cars.Add(newCar);
            ReadCars(carsRemaining, cars);
        }

        public static Engine GetCarEngine(string[] engineData)
        {
            var engineSpeed = double.Parse(engineData[0]);
            var enginePower = double.Parse(engineData[1]);
            var engine = new Engine(engineSpeed, enginePower);

            return engine;
        }

        public static Cargo GetCarCargo(string[] cargoData)
        {
            var cargoWeight = double.Parse(cargoData[0]);
            var cargoType = cargoData[1];
            var cargo = new Cargo(cargoType, cargoWeight);

            return cargo;
        }

        public static List<Tire> GetCarTires(string[] tiresData)
        {
            if (tiresData.Length % 2 != 0) throw new Exception("Odd amount of tires was provided!");

            var tires = new List<Tire>();

            for (int i = 0; i < tiresData.Length; i += 2)
            {
                var tirePressure = double.Parse(tiresData[i]);
                var tireAge = int.Parse(tiresData[i + 1]);
                var newTire = new Tire(tireAge, tirePressure);
                tires.Add(newTire);
            }

            return tires;
        }
    }
}
}
