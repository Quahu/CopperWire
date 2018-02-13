using System;

namespace CopperWire.Logging
{
    /// <summary>
    /// <para>An embedded logger implementation for CopperWire.</para>
    /// <para>This class processes and emits appropriate log events to installed listeners.</para>
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Gets the maximum level of events emitted by this logger.
        /// </summary>
        public LogLevel LogLevel { get; }

        /// <summary>
        /// Initializes this logger instance, setting its maximum logging event to one specified.
        /// </summary>
        /// <param name="level"></param>
        public Logger(LogLevel level)
        {
            this.LogLevel = level;
        }

        /// <summary>
        /// Emits a new log event with specified data.
        /// </summary>
        /// <param name="client">Client instance which emitted this event.</param>
        /// <param name="level">Level of the event.</param>
        /// <param name="tag">Tag of the event.</param>
        /// <param name="message">Message for the event.</param>
        /// <param name="ex">Exception attached to the event.</param>
        public void LogEvent(ClientBase client, LogLevel level, string tag, string message, Exception ex)
        {
            if (level < this.LogLevel)
                return;

            if (this.EventLogged != null)
                this.EventLogged(client, new LogEventArgs(client, level, tag, message, ex));
        }

        /// <summary>
        /// Fired whenever a new log event is emitted.
        /// </summary>
        public event EventHandler<LogEventArgs> EventLogged;
    }

    /// <summary>
    /// Represents arguments for an emitted log event.
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the event source client.
        /// </summary>
        public ClientBase Source { get; }

        /// <summary>
        /// Gets the log level of this event.
        /// </summary>
        public LogLevel LogLevel { get; }

        /// <summary>
        /// Gets the tag attached to this event.
        /// </summary>
        public string Tag { get; }
        
        /// <summary>
        /// Gets the message attached to this event.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the exception attached to this event.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Gets the timestamp attached to this event.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Creates new log event arguments instance.
        /// </summary>
        /// <param name="client">Client from which the event originated.</param>
        /// <param name="level">Level of this log event.</param>
        /// <param name="tag">Tag of this log event.</param>
        /// <param name="message">Message for this log event.</param>
        /// <param name="ex">Exception for this log event.</param>
        internal LogEventArgs(ClientBase client, LogLevel level, string tag, string message, Exception ex)
        {
            this.Source = client;
            this.LogLevel = level;
            this.Tag = tag;
            this.Message = message;
            this.Exception = ex;
        }
    }

    /// <summary>
    /// Determines the log level of log events and logger itself.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// <para>The most verbose of all logging levels.</para>
        /// <para>This level should not be used in production, as it can lead to sensitive data being leaked.</para>
        /// </summary>
        Trace = 0,

        /// <summary>
        /// <para>Very verbose logging level, primarily used to obtain information useful in debugging.</para>
        /// <para>This level should not be used in production, since it will produce a lot of information of little to no value.</para>
        /// </summary>
        Debug = 1,

        /// <summary>
        /// <para>Informative logging level.</para>
        /// <para>This level generally helps keep track of application state.</para>
        /// </summary>
        Information = 2,

        /// <summary>
        /// Warning logging level, which can be used to highlight problems, which do not halt the execution of the program.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Error logging level, which highlights recoverable errors, which halt the execution of the program.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Critical logging level, which highlights unrecoverable errors, indicative of serious issues that require immediate attention.
        /// </summary>
        Critical = 5,

        /// <summary>
        /// <para>Quiet logging level, which swallows all messages.</para>
        /// <para>This is a highly unrecommended level, as it will not display any information at all, including critical errors.</para>
        /// </summary>
        None = 6
    }
}
