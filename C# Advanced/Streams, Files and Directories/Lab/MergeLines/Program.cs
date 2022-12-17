using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var finalOutput = new StringBuilder();

            var firstFileLines = File.ReadAllLines(firstInputFilePath);
            var secondFileLines = File.ReadAllLines(secondInputFilePath);

            var smallerFileLength = firstFileLines.Length >= secondFileLines.Length ? firstFileLines.Length : secondFileLines.Length;
            var lastIndex = smallerFileLength - 1;

            for (int i = 0; i < smallerFileLength; i++)
            {
                finalOutput.AppendLine(firstFileLines[i]);
                finalOutput.AppendLine(secondFileLines[i]);
            }
            if (firstFileLines.Length != secondFileLines.Length)
            {
                var remainingLines = firstFileLines.Length >= secondFileLines.Length ? firstFileLines.Skip(lastIndex) : secondFileLines.Skip(lastIndex);
                var remainingLinesAsString = string.Join("\n", remainingLines);
                finalOutput.AppendLine(remainingLinesAsString);
            }

            File.WriteAllText(outputFilePath, finalOutput.ToString());
        }
    }

}
