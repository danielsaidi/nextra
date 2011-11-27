namespace NExtra.Logging
{
    /// <summary>
    /// This enum defines log levels that can be used
    /// when working with ILogWriter implementations.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public enum LogLevel
    {
        /// <summary>
        /// Debug level - use for debugging.
        /// </summary>
        Debug,

        /// <summary>
        /// Info level - use for non-error info messages.
        /// </summary>
        Info,

        /// <summary>
        /// Warn level - use for non-critical errors.
        /// </summary>
        Warn,

        /// <summary>
        /// Error level - use for critical errors.
        /// </summary>
        Error,

        /// <summary>
        /// Fatal - use for fatal errors.
        /// </summary>
        Fatal,
    }
}
