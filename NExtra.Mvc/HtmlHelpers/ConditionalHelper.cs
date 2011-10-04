using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This class can be used to return one of two possible
    /// return, values depending on a boolean expression.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class ConditionalHelper
    {
        /// <summary>
        /// Return one of two possible return values, depending on a boolean expression.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="expression">Boolean expression.</param>
        /// <param name="trueResult">The value to return if the expression is true.</param>
        /// <param name="falseResult">The value to return if the expression is false.</param>
        /// <returns>The return value.</returns>
        public static T Conditional<T>(this HtmlHelper helper, bool expression, T trueResult, T falseResult)
        {
            return expression ? trueResult : falseResult;
        }
    }
}
