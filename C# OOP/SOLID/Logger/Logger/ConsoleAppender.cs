namespace Logger
{
    using Contracts;
    using Enums;
    using System;
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public int MessagesAppended { get; private set; }

        public ReportLevel ReportLevelThreshold { get; set; }

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
            ReportLevelThreshold = ReportLevel.All;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel < ReportLevelThreshold) return;

            var log = layout.Format(dateTime, reportLevel, message);
            MessagesAppended++;
            Console.WriteLine(log);
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, LayoutType: {layout.GetType().Name}, Report level: {Enum.GetName(typeof(ReportLevel), ReportLevelThreshold)}, Messages appended: {MessagesAppended}";
        }
    }
}
