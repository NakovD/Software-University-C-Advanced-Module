using System;
using System.Collections.Generic;

namespace SetsAndDictionariesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernamesCount = int.Parse(Console.ReadLine());
            var setWithUsernames = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                var currentUsername = Console.ReadLine();
                setWithUsernames.Add(currentUsername);
            }

            Console.WriteLine(string.Join("\n", setWithUsernames));
        }
    }
}
