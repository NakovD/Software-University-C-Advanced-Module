namespace Prototype
{
    using Factories;
    using Models;


    internal class Program
    {
        static void Main(string[] args)
        {
            var sandwichMenu = new SandwichFactory();

            sandwichMenu["burger"] = new Sandwich("beef", "some cheese", "some bread", "tomato, lettuce");
            sandwichMenu["cheeseburger"] = new Sandwich("beef", "a lot of cheese", "some bread", "lettuce");


            var burger = sandwichMenu["burger"].Clone() as Sandwich;
            var cheeseBurger = sandwichMenu["cheeseburger"].Clone() as Sandwich;
        }
    }
}
