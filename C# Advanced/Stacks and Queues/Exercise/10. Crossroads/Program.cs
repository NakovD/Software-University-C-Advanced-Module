using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());
            var passedCars = 0;
            var cars = new Queue<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    var remainingGreenTime = greenLightDuration;
                    while (cars.Count > 0)
                    {
                        if (remainingGreenTime > 0)
                        {
                            var currentCar = cars.Peek();
                            remainingGreenTime = remainingGreenTime - currentCar.Length;
                            if (remainingGreenTime < 0)
                            {
                                var hasCarPassedDuringFreeWindow = freeWindowDuration + remainingGreenTime >= 0;
                                if (!hasCarPassedDuringFreeWindow)
                                {
                                    var indexOfCarHit = currentCar.Length - Math.Abs(freeWindowDuration + remainingGreenTime);
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[indexOfCarHit]}.");
                                    return;
                                }
                                cars.Dequeue();
                                passedCars++;
                            }
                            else
                            {
                                cars.Dequeue();
                                passedCars++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    input = Console.ReadLine();
                    continue;
                }

                cars.Enqueue(input);
                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
