using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday
{
    internal class Program
    {
        private static int wastedFood;

        private static Queue<int> guests;

        private static Stack<int> plates;

        static void Main(string[] args)
        {
            var guestsCapacityArray = Console.ReadLine()
                                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse);

            var platesArray = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse);

            guests = new Queue<int>(guestsCapacityArray);
            plates = new Stack<int>(platesArray);

            ServeGuests();

            if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            else if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }

        private static void ServeGuests()
        {
            if (!guests.Any() || !plates.Any()) return;

            var currentGuest = guests.Peek();
            var currentPlate = plates.Peek();
            plates.Pop();

            if (currentPlate >= currentGuest)
            {
                guests.Dequeue();
                wastedFood += currentPlate - currentGuest;
            }
            else
            {
                currentGuest -= currentPlate;
                FeedGuestUntilFull(currentGuest);
            }
            ServeGuests();
        }

        private static void FeedGuestUntilFull(int guestCapacity)
        {
            while (guestCapacity > 0)
            {
                var nextPlate = plates.Pop();
                if (guestCapacity <= nextPlate)
                {
                    guests.Dequeue();
                    wastedFood += nextPlate - guestCapacity;
                }
                guestCapacity -= nextPlate;
            }
        }
    }
}
