namespace NExtra.Logging
{
    /// <summary>
    /// This class can be used to handle log messages, but
    /// will not do anything with the ones it receives. It
    /// just swallows them with no action whatsoever.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class DoNothingLogWriter : ILogWriter
    {
        public void Log(LogLevel logLevel, string message)
        {
        }
    }
}
