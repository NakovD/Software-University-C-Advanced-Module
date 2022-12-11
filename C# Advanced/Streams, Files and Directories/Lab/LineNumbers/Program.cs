using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);

            using (reader)
            {
                var counter = 1;
                var line = reader.ReadLine();
                var writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    while (line != null)
                    {
                        var lineWithNumber = $"{counter}. {line}";
                        writer.WriteLine(lineWithNumber);
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }

}
