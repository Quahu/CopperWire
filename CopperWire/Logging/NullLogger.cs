using System;
using Microsoft.Extensions.Logging;

namespace CopperWire.Logging
{
    /// <summary>
    /// This is a no-op logger implementation used by CopperWire when no logger is installed in service provder.
    /// </summary>
    /// <typeparam name="T">Logger category.</typeparam>
    public sealed class NullLogger<T> : ILogger<T>, IDisposable
    {
        /// <summary>
        /// This method does nothing. It's there just to satisfy interface implementation.
        /// </summary>
        /// <typeparam name="TState">State type.</typeparam>
        /// <param name="state">State for the scope.</param>
        /// <returns>This logger instance.</returns>
        public IDisposable BeginScope<TState>(TState state)
            => this;

        /// <summary>
        /// This method does nothing. It's there just to satisfy interface implementation.
        /// </summary>
        /// <param name="logLevel">Logging level.</param>
        /// <returns>True.</returns>
        public bool IsEnabled(LogLevel logLevel)
            => true;

        /// <summary>
        /// This method does nothing. It's there just to satisfy interface implementation.
        /// </summary>
        /// <typeparam name="TState">State type.</typeparam>
        /// <param name="logLevel">Logging level.</param>
        /// <param name="eventId">ID of the log event.</param>
        /// <param name="state">State for the event.</param>
        /// <param name="exception">Exception for the event.</param>
        /// <param name="formatter">Formatter used to format the message.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // eat the message
        }

        /// <summary>
        /// This method does nothing. It's there just to satisfy interface implementation.
        /// </summary>
        public void Dispose()
        {
            // do nothing
        }
    }
}
