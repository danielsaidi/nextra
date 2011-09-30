namespace NExtra.Logging
{
    /// <summary>
    /// This ILogWriter can be used to just swallow
    /// all log messages, without doing anything.
    /// </summary>
    public class DoNothingLogWriter : ILogWriter
    {
        /// <summary>
        /// Swallow a log message without doing anything.
        /// </summary>
        /// <param name="logLevel">Message log level.</param>
        /// <param name="message">The message to log.</param>
        public void Log(LogLevel logLevel, string message)
        {
        }
    }
}
