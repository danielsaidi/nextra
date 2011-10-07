using System.Collections.Generic;

namespace NExtra.Abstractions
{
    ///<summary>
    /// This interface can be implemented by classes
    /// that can be used to parse command line args.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICommandLineArgumentParser
    {
        IDictionary<string, string> ParseCommandLineArguments(IEnumerable<string> args);
    }
}
