
using System;

#if MONO
using System.Collections.Generic;
using System.IO;
using System.Text;
#else
using System.Diagnostics;

using DiagELog = System.Diagnostics.EventLog;
#endif

namespace Server
{
#if MONO
	[Flags]
	public enum EventLogEntryType
	{
		Error = 0x01,
		Warning = 0x02,
		Information = 0x04,
		SuccessAudit = 0x08,
		FailureAudit = 0x10
	}

	public static class DiagELog
	{
		private static readonly Dictionary<string, string> _EventLogs = new();

		public static bool SourceExists(string source)
		{
			return Directory.Exists(Path.Combine(Core.BaseDirectory, "Logs", source));
		}

		public static void CreateEventSource(string source, string logName)
		{
			var dir = Path.Combine(Core.BaseDirectory, "Logs", source);

			Directory.CreateDirectory(dir);

			_EventLogs[source] = Path.Combine(dir, $"{logName}.log");
		}

		public static void WriteEntry(string source, string message, EventLogEntryType type, int eventID)
		{
			if (_EventLogs.TryGetValue(source, out var logPath))
			{
				File.AppendAllTextAsync(logPath, $"{type}\t{eventID}\n{DateTime.Now}\n{message}\n\n", Encoding.UTF8);
			}
		}
	}
#else
#pragma warning disable CA1416 // Validate platform compatibility
#endif

	public static class EventLog
	{
		static EventLog()
		{
			if (!DiagELog.SourceExists("uoAvos"))
			{
				DiagELog.CreateEventSource("uoAvos", "Application");
			}
		}

		public static void Error(int eventID, string text)
		{
			DiagELog.WriteEntry("uoAvos", text, EventLogEntryType.Error, eventID);
		}

		public static void Error(int eventID, string format, params object[] args)
		{
			Error(eventID, String.Format(format, args));
		}

		public static void Warning(int eventID, string text)
		{
			DiagELog.WriteEntry("uoAvos", text, EventLogEntryType.Warning, eventID);
		}

		public static void Warning(int eventID, string format, params object[] args)
		{
			Warning(eventID, String.Format(format, args));
		}

		public static void Inform(int eventID, string text)
		{
			DiagELog.WriteEntry("uoAvos", text, EventLogEntryType.Information, eventID);
		}

		public static void Inform(int eventID, string format, params object[] args)
		{
			Inform(eventID, String.Format(format, args));
		}
	}
}