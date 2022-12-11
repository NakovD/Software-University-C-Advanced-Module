namespace Logger.Contracts
{
    using Enums;

    public interface IAppender
    {
        public int MessagesAppended { get; }

        public ReportLevel ReportLevelThreshold { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
