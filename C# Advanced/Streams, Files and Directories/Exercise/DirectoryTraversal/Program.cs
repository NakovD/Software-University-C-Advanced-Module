using System;

namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var sb = new StringBuilder();

            var dir = new DirectoryInfo(inputFolderPath);
            var files = dir.GetFiles();

            var groupedExtensions = files.GroupBy(file => file.Extension, (group, files) => new { Name = group, Files = files.ToArray() });

            var orderedExtensions = groupedExtensions
                .OrderByDescending(group => group.Files.Length)
                .ThenBy(group => group.Name);

            foreach (var group in orderedExtensions)
            {
                sb.AppendLine(group.Name);
                var orderedFiles = group.Files.OrderBy(file => file.Length).Select(file => $"--{file.Name} - {double.Parse(file.Length.ToString()) / 1024:f3}kb");
                sb.AppendLine(string.Join("\n", orderedFiles));
            }
            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            File.WriteAllText($"{desktopPath}{reportFileName}", textContent);
        }
    }
}

