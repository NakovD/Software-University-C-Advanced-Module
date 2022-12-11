using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(input);
            }

            int startIndex = 0;

            while (true)
            {
                int totalLiters = 0;
                bool isComplete = true;

                foreach (int[] item in queue)
                {
                    int liters = item[0];
                    int distance = item[1];

                    totalLiters += liters;

                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = queue.Dequeue();
                        queue.Enqueue(currentPump);
                        isComplete = false;
                        break;
                    }

                    totalLiters -= distance;
                }

                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }
            }
        }
        //static void Main(string[] args)
        //{
        //    var petrolPumps = int.Parse(Console.ReadLine());
        //    var petrolStations = new Queue<PetrolStation>();

        //    for (int i = 0; i < petrolPumps; i++)
        //    {
        //        var input = Console.ReadLine().Split(" ");
        //        var petrolAmount = int.Parse(input[0]);
        //        var distanceToNext = int.Parse(input[1]);
        //        var newStation = new PetrolStation(petrolAmount, distanceToNext);
        //        petrolStations.Enqueue(newStation);
        //    }

        //    var neededIndex = 0;

        //    while (true)
        //    {
        //        var currentLitters = 0;
        //        var isComplete = false;

        //        for (int i = 0; i < petrolStations.Count; i++)
        //        {
        //            var currentPump = petrolStations.Dequeue();
        //            currentLitters += currentPump.petrolAmount;

        //            if (currentLitters - currentPump.distanceToNext < 0)
        //            {
        //                neededIndex++;
        //                petrolStations.Enqueue(currentPump);
        //                isComplete = false;
        //                break;
        //            };

        //            currentLitters -= currentPump.distanceToNext;

        //            if (!isComplete) continue;

        //            Console.WriteLine(neededIndex);
        //            break;
        //        }

        //    }
        //}

    }
    class PetrolStation
    {
        public int petrolAmount { get; set; }
        public int distanceToNext { get; set; }

        public PetrolStation(int petrolAmount, int distanceToNext)
        {
            this.petrolAmount = petrolAmount;
            this.distanceToNext = distanceToNext;
        }
    }
}
