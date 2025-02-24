using System.Diagnostics;

namespace ServerFramework
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new();
        private TraceSource _traceSource;
        private SourceSwitch _sourceSwitch;

        private Logger()
        {
            _sourceSwitch = new SourceSwitch("DefaultSwitch", "All");
            _traceSource = new TraceSource("DefaultLogger", SourceLevels.All)
            {
                Switch = _sourceSwitch
            };

#if DEBUG
            _traceSource.Listeners.Add(new ConsoleTraceListener
            {
                Filter = new EventTypeFilter(SourceLevels.Information)
            });
#endif
        }

        public static Logger Instance => _instance;

        public void Configure(string sourceName, string switchName, SourceLevels level)
        {
            _sourceSwitch = new SourceSwitch(switchName, level.ToString());
            _traceSource = new TraceSource(sourceName, level);
            _traceSource.Switch = _sourceSwitch;
        }

        public void SetLoglevel(SourceLevels level)
        {
            _sourceSwitch.Level = level;
        }

        public void AddListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }

        public void RemoveListener(string listenerName)
        {
            var listener = _traceSource.Listeners[listenerName];
            if (listener != null)
            {
                _traceSource.Listeners.Remove(listener);
                listener.Dispose();
            }
        }

        public void SetListenerFilter(EventTypeFilter filter, string listenerName)
        {
            var listener = _traceSource.Listeners[listenerName];
            if (listener != null)
            {
                listener.Filter = filter;
            }
        }

        public void LogVerbose(string message) => Log(TraceEventType.Verbose, message);
        public void LogInformation(string message) => Log(TraceEventType.Information, message);
        public void LogWarning(string message) => Log(TraceEventType.Warning, message);
        public void LogError(string message) => Log(TraceEventType.Error, message);
        public void LogCritical(string message) => Log(TraceEventType.Critical, message);

        private void Log(TraceEventType eventType, string message)
        {
            _traceSource.TraceEvent(eventType, 0, message);
            _traceSource.Flush();
        }
    }
}
