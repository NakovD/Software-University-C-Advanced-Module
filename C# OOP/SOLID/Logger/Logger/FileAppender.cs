namespace Logger
{
    using Contracts;
    using Enums;
    using System;
    using System.IO;

    public class FileAppender : IAppender
    {
        private ILayout layout;

        private LogFile file;

        public ReportLevel ReportLevelThreshold { get; set; }

        public int MessagesAppended { get; private set; }

        public FileAppender(ILayout layout, LogFile file)
        {
            this.layout = layout;
            this.file = file;
            ReportLevelThreshold = ReportLevel.All;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel < ReportLevelThreshold) return;

            using (var fileWriter = new StreamWriter("../../../log.txt", true))
            {
                var log = layout.Format(dateTime, reportLevel, message);
                file.Write(log);
                fileWriter.WriteLine(log);
                MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, LayoutType: {layout.GetType().Name}, Report level: {Enum.GetName(typeof(ReportLevel), ReportLevelThreshold)}, Messages appended: {MessagesAppended}, File size: {file.Size}";
        }
    }
}
