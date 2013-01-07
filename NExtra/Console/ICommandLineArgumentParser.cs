using System.Collections.Generic;

namespace NExtra.Console
{
    ///<summary>
    /// This interface can be implemented by classes
    /// that can be used to handle command line args.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICommandLineArgumentParser
    {
        /// <summary>
        /// Parse a collection of command line arguments.
        /// </summary>
        IDictionary<string, string> ParseCommandLineArguments(IEnumerable<string> args);
    }
}
