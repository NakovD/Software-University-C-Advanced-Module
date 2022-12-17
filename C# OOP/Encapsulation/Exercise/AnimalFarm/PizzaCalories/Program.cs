using System;
using System.Globalization;
using System.Threading;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var pizzaName = Console.ReadLine().Replace("Pizza ", "");
            var doughData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var dough = new Dough(doughData[1], doughData[2], double.Parse(doughData[3]));
                var pizza = new Pizza(pizzaName, dough);

                var line = Console.ReadLine();

                while (line != "END")
                {
                    var toppingData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var toppingType = toppingData[1];
                    var toppingWeight = double.Parse(toppingData[2]);
                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                    line = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
