namespace NExtra.Logging
{
    /// <summary>
    /// This class can be used to handle log messages. It
    /// will swallow all messages, without doing anything.
    /// </summary>
    public class DoNothingLogWriter : ILogWriter
    {
        /// <summary>
        /// Swallow a log message without doing anything.
        /// </summary>
        public void Log(LogLevel logLevel, string message)
        {
        }
    }
}
