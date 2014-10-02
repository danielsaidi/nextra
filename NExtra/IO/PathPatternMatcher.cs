using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NExtra.IO
{
    /// <summary>
    /// This class can be used to match name patterns of
    /// files and folders, like *.txt, b*, a*.txt etc.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The original implementation was found at this URL:
    /// http://stackoverflow.com/questions/652037/how-do-i-check-if-a-filename-matches-a-wildcard-pattern
    /// Original author: http://stackoverflow.com/users/145211/sprite
    /// 
    /// I have tweaked the original implementation to fit
    /// the coding style of NExtra.
    /// </remarks>
    public class PathPatternMatcher : IPathPatternMatcher
    {
        public static Regex CatchExtentionRegex = new Regex(@"^\s*.+\.([^\.]+)\s*$", RegexOptions.Compiled);
        public static Regex HasQuestionMarkRegEx = new Regex(@"\?", RegexOptions.Compiled);
        public static Regex IlegalCharactersRegex = new Regex("[" + @"\/:<>|" + "\"]", RegexOptions.Compiled);
        public static string NonDotCharacters = @"[^.]*";


        public bool IsAnyMatch(string path, IEnumerable<string> patterns)
        {
            return patterns.Any(pattern => IsMatch(path, pattern));
        }

        public bool IsMatch(string path, string pattern)
        {
            var regex = GetRegexForPattern(pattern);
            return (regex.IsMatch(path));
        }


        private static Regex GetRegexForPattern(string pattern)
        {
            if (pattern == null)
                throw new ArgumentNullException();

            pattern = pattern.Trim();
            if (pattern.Length == 0)
                throw new ArgumentException("Pattern is empty.");

            if (IlegalCharactersRegex.IsMatch(pattern))
                throw new ArgumentException("Patterns contains ilegal characters.");

            var hasExtension = CatchExtentionRegex.IsMatch(pattern);
            var matchExact = ShouldMatchExact(pattern, hasExtension);
            var regexString = GetRegexString(pattern, matchExact, hasExtension);

            var regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex;
        }

        private static string GetRegexString(string pattern, bool matchExact, bool hasExtension)
        {
            var regexString = Regex.Escape(pattern);
            regexString = "^" + Regex.Replace(regexString, @"\\\*", ".*");
            regexString = Regex.Replace(regexString, @"\\\?", ".");

            if (!matchExact && hasExtension)
                regexString += NonDotCharacters;

            regexString += "$";
            return regexString;
        }

        private static bool ShouldMatchExact(string pattern, bool hasExtension)
        {
            if (HasQuestionMarkRegEx.IsMatch(pattern))
                return true;
            
            if (hasExtension)
                return CatchExtentionRegex.Match(pattern).Groups[1].Length != 3;

            return false;
        }
    }
}
