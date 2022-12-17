using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var dir = new DirectoryInfo(folderPath);
            var filesInDirectory = dir.GetFiles("*", SearchOption.AllDirectories);

            decimal sum = 0;

            foreach (var file in filesInDirectory)
            {
                sum += file.Length;
            }
            sum = sum / 1024 / 1024;

            File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}
