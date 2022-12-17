namespace Logger.Contracts
{
    using Enums;
    using System;

    public interface ILayout
    {
        string Format(string dateTime, ReportLevel reportLevel, string message);
    }
}
