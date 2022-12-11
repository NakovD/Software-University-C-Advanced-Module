using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            var words = new List<string>();

            var wordsFileReader = new StreamReader(wordsFilePath);

            using (wordsFileReader)
            {
                var wordsFromFile = wordsFileReader.ReadToEnd();
                words = wordsFromFile.Split(" ").ToList();
            }

            var textFileReader = new StreamReader(textFilePath);

            var textForOutPut = new StringBuilder();

            using (textFileReader)
            {
                var allText = textFileReader.ReadToEnd().ToLower();
                foreach (var word in words)
                {
                    var index = 0;
                    string pattern = @"(\b" + word + ")";
                    while (Regex.IsMatch(allText, pattern))
                    {
                        var regex = new Regex(pattern);
                        allText = regex.Replace(allText, "", 1);
                        index++;
                    }
                    textForOutPut.AppendLine($"{word} - {index}");
                }
            }

            var outputWriter = new StreamWriter(outputFilePath);

            using (outputWriter)
            {
                outputWriter.WriteLine(textForOutPut);
            }
        }
    }
}
