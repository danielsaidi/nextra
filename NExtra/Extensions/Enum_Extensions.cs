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
    public static class Enum_Extensions
    {
        /// <summary>
        /// Add a flag to an enum value and return the resulting value.
        /// </summary>
        public static T AddFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value | (int)(object)flag));
        }

        /// <summary>
        /// Remove a flag from an enum value and return the resulting value.
        /// </summary>
        public static T RemoveFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value & ~(int)(object)flag));
        }
    }
}
