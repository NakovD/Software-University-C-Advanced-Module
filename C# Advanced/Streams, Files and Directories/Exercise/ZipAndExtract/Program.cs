using System;

namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            ZipFile.CreateFromDirectory(inputFilePath, zipArchiveFilePath);
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (var zipArchive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Read))
            {
                var entry = zipArchive.GetEntry(fileName);
                entry.ExtractToFile(outputFilePath);
            }
        }
    }
}
