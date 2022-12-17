using Farm.Animals;
using Farm.Contracts;
using Farm.FoodContracts;
using Farm.Foods;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Farm
{
    public class StartUp
    {
        private static AnimalFactory animalFactory = new AnimalFactory();

        private static List<Animal> animals = new List<Animal>();

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("US");
            ReadCommands();
            animals.ForEach(animal => Console.WriteLine(animal));
        }

        private static void ReadCommands()
        {
            var command = Console.ReadLine();

            if (command == "End") return;

            var animalData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var foodData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var animal = CreateAnimal(animalData);
            var food = CreateFood(foodData);

            animals.Add(animal);

            Console.WriteLine(animal.AskForFood());
            var eatResult = animal.EatFood(food);
            var hasAnimalEaten = string.IsNullOrWhiteSpace(eatResult);
            if (!hasAnimalEaten) Console.WriteLine(eatResult);

            ReadCommands();
        }

        private static Animal CreateAnimal(string[] animalData)
        {
            var animalType = animalData[0];
            var animalName = animalData[1];
            var animalWeight = double.Parse(animalData[2]);
            string animalLivingRegion = null;
            string animalBreed = null;
            double animalWingSize = 0;
            if (animalData.Length == 5)
            {
                animalLivingRegion = animalData[3];
                animalBreed = animalData[4];
            }
            else if (animalData.Length == 4)
            {
                var isBird = double.TryParse(animalData[3], out var wingSize);
                if (isBird)
                {
                    animalWingSize = wingSize;
                }
                else
                {
                    animalLivingRegion = animalData[3];
                }
            }

            return animalFactory.GetAnimal(animalType, animalName, animalWeight, animalLivingRegion, animalBreed, animalWingSize);
        }

        private static Food CreateFood(string[] foodData)
        {
            var foodType = foodData[0];
            var quantity = int.Parse(foodData[1]);

            switch (foodType)
            {
                case "Vegetable": return new Vegetable(quantity);
                case "Fruit": return new Fruit(quantity);
                case "Meat": return new Meat(quantity);
                default: return new Seeds(quantity);
            }
        }
    }
}
