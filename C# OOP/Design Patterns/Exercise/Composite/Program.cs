namespace Composite
{
    using Composite.Models;
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            var gift = new SingleGift("Phone", 100);

            var compositeGift = new CompositeGift("Some box that contains gifs", 1000);

            compositeGift.Add(gift);
            compositeGift.Add(new SingleGift("bread", 20));

            var anotherComposite = new CompositeGift("another box", 50);

            anotherComposite.Add(new SingleGift("slanina", 2.5M));

            compositeGift.Add(anotherComposite);

            Console.WriteLine(compositeGift.CalculateTotalPrice());
        }
    }
}
