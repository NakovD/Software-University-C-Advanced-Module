using System;
using System.Collections.Generic;

namespace _7._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var cars = new HashSet<string>();

            while (!input.Contains("END"))
            {
                var carInfo = input.Split(", ");
                var direction = carInfo[0].ToLower();
                var carNumber = carInfo[1];

                input = Console.ReadLine();

                if (direction == "in")
                {
                    cars.Add(carNumber);
                    continue;
                }

                if (!cars.Contains(carNumber)) continue;

                cars.Remove(carNumber);
            }

            if (cars.Count > 0) Console.WriteLine(string.Join("\n", cars));
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
