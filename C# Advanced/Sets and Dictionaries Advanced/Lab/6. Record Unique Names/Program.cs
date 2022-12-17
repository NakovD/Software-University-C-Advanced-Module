using System;
using System.Collections.Generic;

namespace _6._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfNames = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                var currentName = Console.ReadLine();
                set.Add(currentName);
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
