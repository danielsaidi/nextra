using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to calculate the bearing
    /// between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class BearingCalculator : IBearingCalculator
    {
        private readonly IAngleConverter angleConverter;


        public BearingCalculator(IAngleConverter angleConverter)
        {
            this.angleConverter = angleConverter;
        }


        public double CalculateBearing(IPosition position1, IPosition position2)
        {
            var lat1 = angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var lat2 = angleConverter.ConvertDegreesToRadians(position2.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(position2.Longitude) - angleConverter.ConvertDegreesToRadians(position1.Longitude);

            var y = Math.Sin(dLon) * Math.Cos(lat2);
            var x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);
            var brng = Math.Atan2(y, x);

            return (angleConverter.ConvertRadiansToDegrees(brng) + 360) % 360;
        }
    }
}