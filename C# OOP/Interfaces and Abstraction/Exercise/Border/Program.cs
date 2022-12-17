using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Border.Contracts;

namespace Border
{
    public class StartUp
    {
        private static List<IPerson> buyers = new List<IPerson>();

        private static int totalFoodBought = 0;

        static void Main(string[] args)
        {
            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var currentHumanData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (currentHumanData.Length == 4) CreatePerson(currentHumanData);
                else if (currentHumanData.Length == 3) CreateRebel(currentHumanData);
            }

            ReadPeople();

            Console.WriteLine(totalFoodBought);
        }

        private static void ReadPeople()
        {
            var currentLine = Console.ReadLine();

            if (currentLine == "End") return;

            BuyFood(currentLine);

            ReadPeople();
        }

        private static void BuyFood(string personName)
        {
            var neededPerson = buyers.SingleOrDefault(buyer => (buyer as IPerson).Name == personName);
            if (neededPerson == null) return;

            IBuyer personAsBuyer = (IBuyer)neededPerson;

            totalFoodBought += personAsBuyer.BuyFood();
        }

        private static void CreateRebel(string[] currentHumanData)
        {
            var rebelName = currentHumanData[0];
            var rebelAge = int.Parse(currentHumanData[1]);
            var rebelGroup = currentHumanData[2];

            var rebel = new Rebel(rebelName, rebelAge, rebelGroup);

            buyers.Add(rebel);
        }

        private static void CreatePerson(string[] currentHumanData)
        {
            var personName = currentHumanData[0];
            var personAge = int.Parse(currentHumanData[1]);
            var personId = currentHumanData[2];
            var personBirthdate = currentHumanData[3];

            var person = new Person(personName, personAge, personId, personBirthdate);

            buyers.Add(person);
        }
    }
}
