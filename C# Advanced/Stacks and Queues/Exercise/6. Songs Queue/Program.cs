using System;
using System.Collections.Generic;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ");
            var songsQueue = new Queue<string>(songs);

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || songsQueue.Count == 0) break;
                var command = input.Split(" ")[0];

                switch (command)
                {
                    case "Play":
                        if (songsQueue.Count > 0) songsQueue.Dequeue();
                        break;
                    case "Add":
                        var songToAdd = input.Replace(command + " ", "");
                        if (songsQueue.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                            continue;
                        }
                        songsQueue.Enqueue(songToAdd);
                        break;
                    default:
                        if (songsQueue.Count > 0) Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
