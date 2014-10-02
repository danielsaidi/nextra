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
    public class PositionBearingCalculator : IPositionBearingCalculator
    {
        private readonly IAngleConverter _angleConverter;


        public PositionBearingCalculator(IAngleConverter angleConverter)
        {
            _angleConverter = angleConverter;
        }


        public double CalculateBearing(IPosition pos1, IPosition pos2)
        {
            var lat1 = _angleConverter.ConvertDegreesToRadians(pos1.Latitude);
            var lat2 = _angleConverter.ConvertDegreesToRadians(pos2.Latitude);
            var dLon = _angleConverter.ConvertDegreesToRadians(pos2.Longitude) - _angleConverter.ConvertDegreesToRadians(pos1.Longitude);

            var y = Math.Sin(dLon) * Math.Cos(lat2);
            var x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);
            var brng = Math.Atan2(y, x);

            return (_angleConverter.ConvertRadiansToDegrees(brng) + 360) % 360;
        }

        public double CalculateRhumbBearing(IPosition pos1, IPosition pos2)
        {
            var lat1 = _angleConverter.ConvertDegreesToRadians(pos1.Latitude);
            var lat2 = _angleConverter.ConvertDegreesToRadians(pos2.Latitude);
            var dLon = _angleConverter.ConvertDegreesToRadians(pos2.Longitude - pos1.Longitude);

            var dPhi = Math.Log(Math.Tan(lat2 / 2 + Math.PI / 4) / Math.Tan(lat1 / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI) dLon = (dLon > 0) ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            var brng = Math.Atan2(dLon, dPhi);

            return (_angleConverter.ConvertRadiansToDegrees(brng) + 360) % 360;
        }
    }
}