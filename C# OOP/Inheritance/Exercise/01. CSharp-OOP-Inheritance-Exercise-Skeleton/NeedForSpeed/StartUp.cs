using System;
using System.Globalization;
using System.Threading;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var mc = new Vehicle(250, 150);
            mc.Drive(10);
            Console.WriteLine(mc.Fuel);
        }
    }
}
