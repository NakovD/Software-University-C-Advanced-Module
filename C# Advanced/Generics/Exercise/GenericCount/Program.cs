using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace GenericCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var lines = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < lines; i++)
            {
                var line =  double.Parse(Console.ReadLine());
                list.Add(line);
            }

            var elementToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(Compare(list, elementToCompare));
        }

        static int Compare<T>(List<T> list, T element) where T : IComparable<T>
        {
            var newList = list.Where(e => e.CompareTo(element) == 1);
            return newList.Count();
        }
    }
}
