using System;

namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var fileData = new List<string>();

            var symbolsToReplace = new string[] { "-", ",", ".", "!", "?" };

            var sr = new StreamReader(inputFilePath);

            var index = 1;

            using (sr)
            {

                while (!sr.EndOfStream)
                {
                    var currentLine = sr.ReadLine();
                    index++;
                    if (index % 2 != 0) continue;

                    foreach (var symbol in symbolsToReplace)
                    {
                        currentLine = currentLine.Replace(symbol, "@");
                    }
                    var reverseWords = currentLine.Split(" ").Reverse();

                    fileData.Add(string.Join(" ", reverseWords));
                }
            }
            
            return string.Join("\n", fileData);
        }
    }
}

