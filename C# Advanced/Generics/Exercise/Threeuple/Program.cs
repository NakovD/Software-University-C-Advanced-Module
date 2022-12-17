using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var firstLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var fTuple = (name: firstLine[0] + " " + firstLine[1], address: firstLine[2], town: string.Join(" ", firstLine.Skip(3)));
            var secondLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var sTuple = (name: secondLine[0], int.Parse(secondLine[1]), drunk: secondLine[2] == "drunk");
            var thirdLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var tTuple = (name: thirdLine[0], balance: double.Parse(thirdLine[1]), bankName: thirdLine[2]);

            PrintTuple(fTuple);
            PrintTuple(sTuple);
            PrintTuple(tTuple);
        }

        public static void PrintTuple<T1, T2, T3>((T1, T2, T3) tuple)
        {
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2} -> {tuple.Item3}");
        }
    }
}
