namespace Singleton
{
    using System;

    using Models;

    public class Program
    {
        static void Main(string[] args)
        {
            var singletonContainer = SingletonContainer.Instance;
            singletonContainer = SingletonContainer.Instance;

            Console.WriteLine(singletonContainer.GetPopulation("Blagoevgrad"));
        }
    }
}
