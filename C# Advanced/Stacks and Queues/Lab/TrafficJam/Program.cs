using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsThatCanPass = int.Parse(Console.ReadLine());
            var carsQueue = new Queue<string>();
            var command = Console.ReadLine();
            var carsPassed = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    var index = 0;
                    while (index != carsThatCanPass)
                    {
                        if (carsQueue.Count < 1) break;
                        var passedCar = carsQueue.Dequeue();
                        Console.WriteLine(passedCar + " passed!");
                        carsPassed++;
                        index++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(carsPassed + " cars passed the crossroads.");
        }
    }
}
