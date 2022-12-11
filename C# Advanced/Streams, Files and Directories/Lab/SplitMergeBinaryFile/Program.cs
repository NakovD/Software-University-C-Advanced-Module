using System;
using System.IO;
using System.Linq;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            var binaryFileData = new byte[4096];

            using (var fs = new FileStream(sourceFilePath, FileMode.Open))
            {
                fs.Read(binaryFileData);
            }

            var firstFileLength = binaryFileData.Length % 2 != 0 ? binaryFileData.Length / 2 + 1 : binaryFileData.Length / 2;
            var firstFileData = binaryFileData.Take(firstFileLength).ToArray();
            var secondFileData = binaryFileData.Skip(firstFileLength).ToArray();

            File.WriteAllBytes(partOneFilePath, firstFileData);
            File.WriteAllBytes(partTwoFilePath, secondFileData);
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            var firstFileData = File.ReadAllBytes(partOneFilePath);
            var secondFileData = File.ReadAllBytes(partTwoFilePath);

            using (var writeStream = new FileStream(joinedFilePath, FileMode.Create))
            {
                writeStream.Write(firstFileData.Concat(secondFileData).ToArray());
            }
        }
    }
}
