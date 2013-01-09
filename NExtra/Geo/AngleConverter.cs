using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to convert angular values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class AngleConverter : IAngleConverter
    {
        public double ConvertDegreesToRadians(double degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        public double ConvertRadiansToDegrees(double radians)
        {
            return 180.0 * radians / Math.PI;
        }
    }
}
