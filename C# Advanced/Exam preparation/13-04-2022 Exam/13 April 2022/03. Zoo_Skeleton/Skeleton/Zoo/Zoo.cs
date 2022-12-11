using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zoo
{
    public class Zoo
    {
        public List<Animal> Animals { get; private set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species)) return "Invalid animal species.";

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore") return "Invalid animal diet.";

            if (Capacity == 0) return "The zoo is full.";

            Capacity--;

            this.Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var removedAnimals = this.Animals.RemoveAll(animal => animal.Species == species);

            this.Capacity += removedAnimals;

            return removedAnimals;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var neededAnimals = this.Animals.Where(animal => animal.Diet == diet).ToList();

            return neededAnimals;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            var neededAnimal = this.Animals.SingleOrDefault(animal => animal.Weight == weight);

            return neededAnimal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var validaAnimals = this.Animals.FindAll(animal => animal.Length >= minimumLength && animal.Length <= maximumLength);

            return $"There are {validaAnimals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
