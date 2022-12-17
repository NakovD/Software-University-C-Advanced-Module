using System;
using System.Globalization;
using System.Threading;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            ////var cake = new Cake("Cake");
            //var soup = new Soup("soup", 1.5M, 550);
            ////Console.WriteLine(soup.Price);
            //Console.WriteLine(cake.Grams);
            //cake.Grams = 100;
            //Console.WriteLine(cake.Grams);
            //var fish = new Fish("fish", 5, 15);
            ////Console.WriteLine(fish.Grams);
        }
    }
}