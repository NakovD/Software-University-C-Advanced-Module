namespace Logger
{
    using Contracts;
    using Enums;
    using System;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format(string dateTime, ReportLevel reportLevel, string message)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{dateTime}</date>");
            sb.AppendLine($"    <level>{Enum.GetName(typeof(ReportLevel), reportLevel)}</level>");
            sb.AppendLine($"    <message>{message}</message>");
            sb.AppendLine("</log>");

            return sb.ToString().Trim();
        }
    }
}