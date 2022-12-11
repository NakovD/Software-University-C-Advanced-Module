namespace Command
{
    using Contracts;
    using Enums;
    using Models;

    using System;

    public class Program
    {
        private static ModifyPrice priceModifier;
        static void Main(string[] args)
        {
            priceModifier = new ModifyPrice();
            var product = new Product("Toothpaste", 500);

            ExecuteCommand(new ProductCommand(product, PriceAction.Increase, 300));
            ExecuteCommand(new ProductCommand(product, PriceAction.Decrease, 400));
            ExecuteCommand(new ProductCommand(product, PriceAction.Decrease, 300));

            Console.WriteLine(product);
        }

        private static void ExecuteCommand(ICommand command)
        {
            priceModifier.SetCommand(command);
            priceModifier.Invoke();
        }
    }
}
