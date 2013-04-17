using System.Collections.Generic;

namespace NExtra.Console
{
    ///<summary>
    /// This interface can be implemented by classes that
    /// can be used to parse command line arguments.
    /// 
    /// Due to the expected parse method return result, I
    /// advice you only to use this interface when you do
    /// expect keys and values as return values.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICommandLineArgumentParser
    {
        IDictionary<string, string> ParseCommandLineArguments(IEnumerable<string> args);
    }
}
