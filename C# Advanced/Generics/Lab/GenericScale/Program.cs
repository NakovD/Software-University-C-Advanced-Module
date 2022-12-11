using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<string>("hello", "hello");

            Console.WriteLine(scale.AreEqual());
        }
    }
}
