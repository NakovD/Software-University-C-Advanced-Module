namespace Logger
{
    using Contracts;
    using Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>(appenders);
        }

        public void Info(string dateTime, string message)
        {
            appenders.ForEach(appender => appender.Append(dateTime, ReportLevel.INFO, message));
        }

        public void Warning(string dateTime, string message)
        {
            appenders.ForEach(appender => appender.Append(dateTime, ReportLevel.WARNING, message));
        }

        public void Error(string dateTime, string message)
        {
            appenders.ForEach(appender => appender.Append(dateTime, ReportLevel.ERROR, message));
        }

        public void Critical(string dateTime, string message)
        {
            appenders.ForEach(appender => appender.Append(dateTime, ReportLevel.CRITICAL, message));
        }

        public void Fatal(string dateTime, string message)
        {
            appenders.ForEach(appender => appender.Append(dateTime, ReportLevel.FATAL, message));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Logger info");
            sb.AppendLine(string.Join(Environment.NewLine, appenders));

            return sb.ToString().Trim();
        }
    }
}
