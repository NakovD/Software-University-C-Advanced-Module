namespace Singleton.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Contracts;

    public class SingletonContainer : ISingletonContainer
    {
        private static ISingletonContainer instance;


        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        public static ISingletonContainer Instance { get => GetSingletonInstance(); }

        private SingletonContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadLines("../../../capitals.txt").ToArray();

            for (int i = 0; i < elements.Length; i += 2)
            {
                var capitalName = elements[i];
                var capitalPopulation = int.Parse(elements[i + 1]);

                capitals.Add(capitalName, capitalPopulation);
            }
        }

        private static ISingletonContainer GetSingletonInstance()
        {
            if (instance == null)
            {
                instance = new SingletonContainer();
            }

            return instance;
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
