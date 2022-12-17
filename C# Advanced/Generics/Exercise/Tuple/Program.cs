using System;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var firstLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var fName = firstLine[0];
            var lName = firstLine[1];
            var address = firstLine[2];
            var secondLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var personName = secondLine[0];
            var litersOfBeer = int.Parse(secondLine[1]);
            var thirdLine = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var inte = int.Parse(thirdLine[0]);
            var doub = double.Parse(thirdLine[1]);

            var fTuple = new Tuple<string, string>(fName + " " + lName, address);
            var sTuple = new Tuple<string, int>(personName, litersOfBeer);
            var tTuple = new Tuple<int, double>(inte, doub);

            Console.WriteLine(fTuple);
            Console.WriteLine(sTuple);
            Console.WriteLine(tTuple);
        }
    }

    public class Tuple<T1, T2>
    {
        public T1 item1 { get; set; }

        public T2 item2 { get; set; }


        public Tuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }


        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
