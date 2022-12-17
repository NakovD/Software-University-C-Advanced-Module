using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {

            var bytesToFind = File.ReadAllLines(bytesFilePath);

            var buffer = new byte[4096];

            var outputBytes = new byte[4096];

            using (var fs = new FileStream(binaryFilePath, FileMode.Open))
            {
                fs.Read(buffer);
            }

            outputBytes = buffer.Where(bute => bytesToFind.Contains(bute.ToString())).ToArray();

            using (var fs = new FileStream(outputPath, FileMode.Create))
            {
                fs.Write(outputBytes);
            }
        }
    }
}

