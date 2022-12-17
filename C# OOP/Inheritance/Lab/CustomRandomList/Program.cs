using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList() { "hi", "hello", "wattup", "geegee", "nope", "hello there"};
            Console.WriteLine(randomList.RandomString());
        }
    }
}
