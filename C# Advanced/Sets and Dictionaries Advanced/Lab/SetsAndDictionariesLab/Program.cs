using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace SetsAndDictionariesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var numbers = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var dictionary = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number] = dictionary[number] + 1;
                    continue;
                }
                dictionary.Add(number, 1);
            }


            foreach (var number in dictionary)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
