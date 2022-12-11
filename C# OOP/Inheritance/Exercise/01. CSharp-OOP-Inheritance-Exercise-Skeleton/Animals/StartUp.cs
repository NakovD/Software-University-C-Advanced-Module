using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var animalType = input.ToLower();
                var animalData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal;
                try
                {
                    if (animalType == "cat")
                    {
                        animal = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                    }
                    else if (animalType == "dog")
                    {
                        animal = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                    }
                    else if (animalType == "frog")
                    {
                        animal = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                    }
                    else if (animalType == "kitten")
                    {
                        animal = new Kitten(animalData[0], int.Parse(animalData[1]), animalData[2]);
                    }
                    else
                    {
                        animal = new Tomcat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                    }
                    Console.WriteLine(input);
                    Console.WriteLine(animal);
                    Console.WriteLine(animal.ProduceSound());
                    input = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    input = Console.ReadLine();
                }
               
                
            }
        }

    }
}
