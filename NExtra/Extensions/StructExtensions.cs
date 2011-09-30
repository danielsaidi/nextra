namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for struct.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class StructExtensions
    {
        ///<summary>
        ///Check whether or not a struct has its default value.
        ///</summary>
        ///<param name="value">The value of interest.</param>
        ///<typeparam name="T">The struct type.</typeparam>
        ///<returns>Whether or not the struct has its default value.</returns>
        public static bool IsDefault<T>(this T value) where T : struct
        {
            return value.Equals(default(T));
        }
    }
}
