namespace NExtra.Logging
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to log messages. An implementation could, for
    /// instance, wrap log4net to simplify testing.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ILogWriter
    {
        /// <summary>
        /// Log a certain message.
        /// </summary>
        /// <param name="logLevel">The message log level, e.g. Debug.</param>
        /// <param name="message">The message to log.</param>
        void Log(LogLevel logLevel, string message);
    }
}
