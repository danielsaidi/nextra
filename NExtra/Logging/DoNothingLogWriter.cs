namespace NExtra.Logging
{
    /// <summary>
    /// This class can be used to handle logging, but will
    /// not do anything. It just swallows log messages and
    /// pretends like everything went just fine.
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
