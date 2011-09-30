using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to convert angle  units.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class AngleConverter
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        /// <param name="angle">The angle, in degrees.</param>
        /// <returns>The angle, in radians.</returns>
        public double ConvertDegreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="angle">The angle, in radians.</param>
        /// <returns>The angle, in degrees.</returns>
        public double ConvertRadiansToDegrees(double angle)
        {
            return 180.0 * angle / Math.PI;
        }
    }
}
