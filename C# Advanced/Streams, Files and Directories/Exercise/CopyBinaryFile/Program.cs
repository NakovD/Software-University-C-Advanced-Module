using System;

namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            var inputBinaryFileReader = new FileStream(inputFilePath, FileMode.Open);

            var buffer = new byte[10 * 1024];

            using (inputBinaryFileReader)
            {
                var fileData = inputBinaryFileReader.Read(buffer);
            }

            var outputFileWriter = new FileStream(outputFilePath, FileMode.Create);

            using (outputFileWriter)
            {
                outputFileWriter.Write(buffer);
            }
        }
    }
}

