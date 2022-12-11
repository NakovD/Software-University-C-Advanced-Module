using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var input = Console.ReadLine();

            const decimal VAT = 1.2M;

            var pricesWithVat = input
                .Split(", ")
                .Select(decimal.Parse)
                .Select(price => price * VAT)
                .Select(price => $"{price:f2}");

            Console.WriteLine(string.Join(Environment.NewLine, pricesWithVat));
        }
    }
}
