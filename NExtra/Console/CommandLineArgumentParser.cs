﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NExtra.Console
{
    /// <summary>
    /// This class can be used to parse command line args
    /// that follow any of the following formats:
    /// /name=Stefan
    /// --name=Stefan
    /// --name="Multiple words"
    /// -name 'Stefan'
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The original implementation by Richard Lopes has
    /// been changed so that it implements the interface
    /// ICommandLineArgumentParser. The original classes
    /// can be found at:
    /// http://www.codeproject.com/KB/recipes/command_line.aspx 
    /// </remarks>
    public class CommandLineArgumentParser : ICommandLineArgumentParser<IDictionary<string, string>>
    {
        private readonly Regex _splitter;
        private readonly Regex _remover;


        public CommandLineArgumentParser()
        {
            _splitter = new Regex(@"^-{1,2}|^/|=|:", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            _remover = new Regex(@"^['""]?(.*?)['""]?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }


        public IDictionary<string, string> ParseCommandLineArguments(IEnumerable<string> args)
        {
            string parameter = null;
            var parameters = new Dictionary<string, string>();

            // Valid parameters forms:
            // {-,/,--}param{ ,=,:}((",')value(",'))
            // Examples: 
            // -param1 value1 --param2 /param3:"Test-:-work" /param4=happy -param5 '--=nice=--'
            foreach (var parts in args.Select(arg => _splitter.Split(arg, 3)))
            {
                switch (parts.Length)
                {
                        // Found a value (for the last parameter found (space separator))
                    case 1:
                        parameter = ParseValue(parts, parameter, parameters);
                        break;

                        // Found just a parameter
                    case 2:
                        parameter = ParseParameter(parts, parameter, parameters);
                        break;

                        // Parameter with enclosed value
                    case 3:
                        parameter = ParseParameterWithEnclosedValue(parts, parameter, parameters);
                        break;
                }
            }

            if (parameter != null && !parameters.ContainsKey(parameter))
                parameters.Add(parameter, "true");

            return parameters;
        }


        private static string ParseParameter(IList<string> parts, string parameter, IDictionary<string, string> parameters)
        {
            // The last parameter is still waiting. With no value, set it to true.

            if (parameter != null && !parameters.ContainsKey(parameter))
                parameters.Add(parameter, "true");

            parameter = parts[1];
            return parameter;
        }

        private string ParseParameterWithEnclosedValue(IList<string> parts, string parameter, IDictionary<string, string> parameters)
        {
            // The last parameter is still waiting. With no value, set it to true.
            if (parameter != null)
            {
                if (!parameters.ContainsKey(parameter))
                    parameters.Add(parameter, "true");
            }

            parameter = parts[1];

            // Remove possible enclosing characters (",')
            if (parameters.ContainsKey(parameter)) return null;

            parts[2] = _remover.Replace(parts[2], "$1");
            parameters.Add(parameter, parts[2]);

            return null;
        }

        private string ParseValue(IList<string> parts, string parameter, IDictionary<string, string> parameters)
        {
            if (parameter == null || parameters.ContainsKey(parameter)) return null;

            parts[0] = _remover.Replace(parts[0], "$1");
            parameters.Add(parameter, parts[0]);

            return null;

            // else Error: no parameter waiting for a value (skipped)
        }
    }
}
