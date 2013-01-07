using System.Collections.Generic;

namespace NExtra.Console
{
    ///<summary>
    /// This interface can be implemented by classes that can
    /// be used to parse command line arguments.
    /// 
    /// Due to the expected return result of the parse method,
    /// this interface should only be used when the arguments
    /// are expected to be keys and values.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICommandLineArgumentParser
    {
        /// <summary>
        /// Parse a collection of command line arguments into
        /// a key/value collection.
        /// </summary>
        IDictionary<string, string> ParseCommandLineArguments(IEnumerable<string> args);
    }
}
