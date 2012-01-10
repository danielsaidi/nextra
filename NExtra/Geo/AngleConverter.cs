using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to convert angles in
    /// various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class AngleConverter : IAngleConverter
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        public double ConvertDegreesToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        public double ConvertRadiansToDegrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }
    }
}
