namespace DI_Implementation.Loggers
{
    using DI_Implementation.Loggers.Contracts;

    public class FileLogger : ILogger
    {
        private const string defaultFilePath = "../../../log.txt";

        private string filePath;

        private const string errorOutline = "<error>{0}<error>";
        private const string fatalOutline = "<fatal>{0}<fatal>";
        private const string infoOutline = "<info>{0}<info>";
        private const string warnOutline = "<warn>{0}<warn>";

        public FileLogger()
        {
            filePath = defaultFilePath;
        }

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void Error(string message)
        {

            using (var sw = new StreamWriter(filePath, true))
            {
                var errorMessage = string.Format(errorOutline, message);
                
                sw.WriteLine(errorMessage);
            }
        }

        public void Fatal(string message)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                var fatalMessage = string.Format(fatalOutline, message);
                sw.WriteLine(fatalMessage);
            }
        }

        public void Info(string message)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                var infoMessage = string.Format(infoOutline, message);
                sw.WriteLine(infoMessage);
            }
        }

        public void Warn(string message)
        {
            using (var sw = new StreamWriter(filePath, true))
            {
                var warnMessage = string.Format(warnOutline, message);
                sw.WriteLine(warnMessage);
            }
        }
    }
}
