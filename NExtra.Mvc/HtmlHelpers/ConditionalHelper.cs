using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This class can be used to get one of two possible
    /// values, depending on a boolean expression.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class ConditionalHelper
    {
        public static T Conditional<T>(this HtmlHelper helper, bool expression, T trueResult, T falseResult)
        {
            return expression ? trueResult : falseResult;
        }
    }
}
