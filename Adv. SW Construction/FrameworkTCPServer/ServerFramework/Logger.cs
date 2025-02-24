using System.Diagnostics;

namespace ServerFramework
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new();
        private readonly TraceSource _traceSource;
        private readonly SourceSwitch _sourceSwitch;
        private static readonly string _logPath = "../../../../server.log";

        private Logger()
        {
            _sourceSwitch = new SourceSwitch("LoggerSourceSwitch", "Information");
            _traceSource = new TraceSource("Logger", SourceLevels.All)
            {
                Switch = _sourceSwitch
            };

            _traceSource.Listeners.Add(new ConsoleTraceListener
            {
                Filter = new EventTypeFilter(SourceLevels.Information)
            });

            _traceSource.Listeners.Add(new TextWriterTraceListener(_logPath)
            {
                Filter = new EventTypeFilter(SourceLevels.Warning)
            });

            if (OperatingSystem.IsWindows() && !EventLog.SourceExists("AbstractTCPServer"))
            {
                try
                {
                    EventLog.CreateEventSource("AbstractTCPServer", "Application");
                }

                catch (Exception ex)
                {
                    LogError($"Error creating event log source: {ex.Message}");
                }
            }

            if (OperatingSystem.IsWindows())
            {
                _traceSource.Listeners.Add(new EventLogTraceListener("AbstractTCPServer")
                {
                    Filter = new EventTypeFilter(SourceLevels.Error)
                });
            }
        }

        public static Logger Instance => _instance;

        public void SetLoglevel(SourceLevels level)
        {
            _sourceSwitch.Level = level;
        }

        public void LogInformation(string message)
        {
            _traceSource.TraceInformation(message);
            _traceSource.Flush();
        }

        public void LogError(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, message);
            _traceSource.Flush();
        }

        public void LogWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 0, message);
            _traceSource.Flush();
        }
    }
}
