using System.Collections.Generic;

namespace NExtra.Console
{
    /// <summary>
    /// This class can be used to parse command line args
    /// into a typed CommandLineArguments instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class TypedCommandLineArgumentParser : ICommandLineArgumentParser<CommandLineArguments>
    {
        private readonly ICommandLineArgumentParser<IDictionary<string, string>> baseParser;

        
        public TypedCommandLineArgumentParser(ICommandLineArgumentParser<IDictionary<string, string>> baseParser)
        {
            this.baseParser = baseParser;
        }

        
        public CommandLineArguments ParseCommandLineArguments(IEnumerable<string> args)
        {
            var dict = baseParser.ParseCommandLineArguments(args);
            var result = new CommandLineArguments(dict);

            return result;
        }
    }
}
