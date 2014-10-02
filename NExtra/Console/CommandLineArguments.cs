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
        private readonly IDictionary<string, string> _args;


        public CommandLineArguments(IDictionary<string, string> args)
        {
            _args = args;
        }


        public IDictionary<string, string> Raw
        {
            get { return _args; }
        }


        public bool HasArgument(string key)
        {
            return (_args.ContainsKey(key));
        }

        public bool HasArgument(string key, string value)
        {
            return (_args.ContainsKey(key) && _args[key] == value);
        }

        public bool HasSingleArgument(string key)
        {
            return _args.Count == 1 && HasArgument(key);
        }

        public bool HasSingleArgument(string key, string value)
        {
            return _args.Count == 1 && HasArgument(key, value);
        }
    }
}
