using System;
using System.Globalization;
using System.Threading;

namespace Vehicles
{
    public class StartUp
    {
        private static Car car;

        private static Truck truck;

        private static Bus bus;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("US");
            var carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateCar(carInfo);
            var truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateTruck(truckInfo);
            var busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            CreateBus(busInfo);

            var commands = int.Parse(Console.ReadLine());

            for (int i = 0; i < commands; i++)
            {
                var currentCommand = Console.ReadLine();
                ExecuteCommand(currentCommand);
            }

            Console.WriteLine(car.GetFuelStatus());
            Console.WriteLine(truck.GetFuelStatus());
            Console.WriteLine(bus.GetFuelStatus());
        }

        private static void ExecuteCommand(string command)
        {
            Vehicle vehicle = null;
            var isCar = command.Contains("Car");
            var isTruck = command.Contains("Truck");
            if (isCar) vehicle = car;
            else if (isTruck) vehicle = truck;
            else vehicle = bus;

            var commandData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var action = commandData[0];

            if (action == "Drive")
            {
                var distance = double.Parse(commandData[2]);
                if (vehicle is Bus)
                {
                    var bus = vehicle as Bus;
                    bus.HasPeople = true;
                }
                Console.WriteLine(vehicle.Drive(distance));
            }
            else if (action == "DriveEmpty")
            {
                var distance = double.Parse(commandData[2]);
                var bus = vehicle as Bus;
                bus.HasPeople = false;
                Console.WriteLine(bus.Drive(distance));
            }
            else
            {
                var liters = double.Parse(commandData[2]);
                if (liters <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    return;
                }
                if (liters > vehicle.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                    return;
                }

                vehicle.Refuel(liters);
            }
        }

        private static void CreateBus(string[] busInfo)
        {
            bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
        }

        private static void CreateTruck(string[] truckInfo)
        {
            truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        }

        private static void CreateCar(string[] carInfo)
        {
            car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        }
    }
}
