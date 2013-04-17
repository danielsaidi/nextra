namespace NExtra.Logging
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used handle logging. Implementations could,
    /// for instance, wrap log4net.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ILogWriter
    {
        void Log(LogLevel logLevel, string message);
    }
}
