using System.Collections.Generic;

namespace NExtra.Console
{
    /// <summary>
    /// This class represents command line arguments that
    /// are passed into a command line application.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class CommandLineArguments
    {
        private readonly IDictionary<string, string> args;


        public CommandLineArguments(IDictionary<string, string> args)
        {
            this.args = args;
        }


        public IDictionary<string, string> Raw
        {
            get { return args; }
        }


        public bool HasArgument(string key)
        {
            return (args.ContainsKey(key));
        }

        public bool HasArgument(string key, string value)
        {
            return (args.ContainsKey(key) && args[key] == value);
        }

        public bool HasSingleArgument(string key)
        {
            return args.Count == 1 && HasArgument(key);
        }

        public bool HasSingleArgument(string key, string value)
        {
            return args.Count == 1 && HasArgument(key, value);
        }
    }
}
