namespace Logger
{
	using Contracts;
	using Enums;
	using System;
	using System.Collections.Generic;

	public class CommandInterpreter
    {
		private List<IAppender> appenders;

		public IReadOnlyCollection<IAppender> Appenders
		{
			get { return appenders.AsReadOnly(); }
		}

		public CommandInterpreter()
		{
			appenders = new List<IAppender>();
		}

		public void ReadAppenders()
		{
			var lines = int.Parse(Console.ReadLine());

			for (int i = 0; i < lines; i++)
			{
				var line = Console.ReadLine();
				var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
				ILayout layout = GetLayout(data[1]);
				var appender = GetAppenderType(data[0], layout);
				var reportLevelString = data.Length == 2 ? "Äll" : data[2];
				var reportLevel = GetReportLevel(reportLevelString);
				appender.ReportLevelThreshold = reportLevel;
				appenders.Add(appender);
			}
		}

		private ReportLevel GetReportLevel(string reportLevel)
		{
			reportLevel = reportLevel.ToLower();

			switch (reportLevel)
			{
				case "info": return ReportLevel.INFO;
				case "warning": return ReportLevel.WARNING;
				case "error": return ReportLevel.ERROR;
				case "critical": return ReportLevel.CRITICAL;
				case "fatal": return ReportLevel.FATAL;
				default: return ReportLevel.All;
			}
		}

		private ILayout GetLayout(string layoutType)
		{
			if (layoutType == "SimpleLayout") return new SimpleLayout();
			else return new XmlLayout();
		}

		private IAppender GetAppenderType(string appenderType, ILayout layout)
		{
			if (appenderType == "ConsoleAppender") return new ConsoleAppender(layout);
			else return new FileAppender(layout, new LogFile());
		}
	}
}
