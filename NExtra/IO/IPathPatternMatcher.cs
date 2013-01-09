using System.Collections.Generic;

namespace NExtra.IO
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to match file and directory paths (e.g. *.txt).
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPathPatternMatcher
    {
        bool IsAnyMatch(string path, IEnumerable<string> patterns);
        bool IsMatch(string path, string pattern);
    }
}
