using System;
using System.Globalization;
using System.Threading;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                var box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }
    }
}
