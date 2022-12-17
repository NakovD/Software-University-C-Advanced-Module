using System;
using System.IO;

namespace SteamsFilesDirectoriesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../Files For Testing");

            Console.WriteLine(string.Join("\n", files));
        }
    }
}
