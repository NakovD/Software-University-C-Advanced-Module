namespace Logger
{
    using Contracts;
    using Enums;
    using System;

    public class SimpleLayout : ILayout
    {
        public string Format(string dateTime, ReportLevel reportLevel, string message)
        {
            return $"{dateTime} - {Enum.GetName(typeof(ReportLevel), reportLevel)} - {message}";
        }
    }
}
