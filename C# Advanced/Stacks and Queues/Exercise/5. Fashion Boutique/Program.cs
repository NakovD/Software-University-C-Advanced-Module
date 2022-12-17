using System;
using System.Collections.Generic;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split(" ");
            var rackCapacity = int.Parse(Console.ReadLine());
            var clothesInStack = new Stack<int>(Array.ConvertAll(clothes, cloth => int.Parse(cloth)));

            var racksUsed = 1;
            var sumOfClothes = 0;

            while (clothesInStack.Count > 0)
            {
                var currentCloth = clothesInStack.Pop();
                sumOfClothes += currentCloth;

                //Conditions
                var clothesAreMoreThanRackCapacity = sumOfClothes > rackCapacity;
                var clothesAreEqualToRackCapacity = sumOfClothes == rackCapacity;

                if (clothesAreMoreThanRackCapacity) { racksUsed++; sumOfClothes = currentCloth; };
                if (clothesAreEqualToRackCapacity && clothesInStack.Count > 0) { racksUsed++; sumOfClothes = 0; };
            }

            Console.WriteLine(racksUsed);
        }
    }
}
