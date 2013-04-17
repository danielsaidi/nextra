using System;

namespace NExtra.Console
{
    ///<summary>
    /// This interface represents the most basic parts of
    /// the static Console class. If more methods from it
    /// are needed, simply add them to the interface.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IConsole
    {
        int Read();
        ConsoleKeyInfo ReadKey();
        string ReadLine();
        void Write(string value);
        void WriteLine(string value);
    }
}
