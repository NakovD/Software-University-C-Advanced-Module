using System;

namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            //string inputPath = @$"{Console.ReadLine()}";
            string inputPath = @"../../../OldDir/";
            //string outputPath = @$"{Console.ReadLine()}";
            string outputPath = @"../../../NewDir/";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            var dir = new DirectoryInfo(inputPath);
            var dirFiles = dir.GetFiles();

            var outputDirExists = Directory.Exists(outputPath);

            if (outputDirExists)
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            foreach (var file in dirFiles)
            {
                var currentFilePath = outputPath + file.Name;
                var currentFileData = File.ReadAllText(file.FullName);
                File.WriteAllText(currentFilePath, currentFileData);
            }
        }
    }
}

