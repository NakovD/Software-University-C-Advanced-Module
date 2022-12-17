using System;
using System.IO;
using System.Linq;
using System.Text;


namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main(string[] args)
        {

        }
        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var inputFileLines = File.ReadAllLines(inputFilePath);

            var finalString = inputFileLines.Select((line, Index) =>
            {
                var letters = line.Aggregate(0, (acc, next) =>
                {
                    var character = next.ToString().ToLower();
                    var asciValue = Encoding.ASCII.GetBytes(character)[0];
                    if (asciValue > 96 && asciValue < 123) acc++;
                    return acc;
                });
                var lineWithoutSpaces = line.Replace(" ", string.Empty);
                var punctuationMarks = lineWithoutSpaces.Length - letters;
                return $"Line {Index + 1}: {line} ({letters})({punctuationMarks})";
            });

            File.WriteAllLines(outputFilePath, finalString);
        }
    }
}


