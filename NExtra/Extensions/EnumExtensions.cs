using System;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.UInt32 / System.Int32 that
    /// can be used for flag enum operations.
    /// </summary>
    /// <remarks>
    /// For now, enums has to be cast to ints/uints if they are
    /// to be used by the class. This class should be rewritten
    /// to work only with enums.
    /// 
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class EnumExtensions
    {
        /// <summary>
        /// Add a flag value to an enum value.
        /// </summary>
        /// <param name="value">The original enum value.</param>
        /// <param name="flag">The flag value to add.</param>
        public static T AddFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value | (int)(object)flag));
        }

        /// <summary>
        /// Remove a flag value from an enum.
        /// </summary>
        /// <param name="value">The original value.</param>
        /// <param name="flag">The flag value to remove.</param>
        public static T RemoveFlag<T>(this Enum value, T flag)
        {
            return (T)(object)(((int)(object)value & ~(int)(object)flag));
        }
    }
}
