using System;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.UInt32 / System.Int32 that
    /// can be used for flag enum operations.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class EnumExtensions
    {
        /// <summary>
        /// Add a flag value to an enum value.
        /// </summary>
        public static T AddFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value | (int)(object)flag));
        }

        /// <summary>
        /// Remove a flag value from an enum.
        /// </summary>
        public static T RemoveFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value & ~(int)(object)flag));
        }
    }
}
