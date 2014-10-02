using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to calculate the distance
    /// between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class PositionDistanceCalculator : IPositionDistanceCalculator
    {
        private readonly IAngleConverter _angleConverter;


        public PositionDistanceCalculator(IAngleConverter angleConverter)
        {
            _angleConverter = angleConverter;
        }


        public double CalculateDistance(IPosition pos1, IPosition pos2, DistanceUnit unit)
        {
            var r = (unit == DistanceUnit.Miles) ? GeoConstants.EarthRadiusInMiles : GeoConstants.EarthRadiusInKilometers;
            var dLat = _angleConverter.ConvertDegreesToRadians(pos2.Latitude) - _angleConverter.ConvertDegreesToRadians(pos1.Latitude);
            var dLon = _angleConverter.ConvertDegreesToRadians(pos2.Longitude) - _angleConverter.ConvertDegreesToRadians(pos1.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(_angleConverter.ConvertDegreesToRadians(pos1.Latitude)) * Math.Cos(_angleConverter.ConvertDegreesToRadians(pos2.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = c * r;

            return Math.Round(distance, 2);
        }

        public double CalculateRhumbDistance(IPosition pos1, IPosition pos2, DistanceUnit unit)
        {
            var r = (unit == DistanceUnit.Miles) ? GeoConstants.EarthRadiusInMiles : GeoConstants.EarthRadiusInKilometers;
            var lat1 = _angleConverter.ConvertDegreesToRadians(pos1.Latitude);
            var lat2 = _angleConverter.ConvertDegreesToRadians(pos2.Latitude);
            var dLat = _angleConverter.ConvertDegreesToRadians(pos2.Latitude - pos1.Latitude);
            var dLon = _angleConverter.ConvertDegreesToRadians(Math.Abs(pos2.Longitude - pos1.Longitude));

            var dPhi = Math.Log(Math.Tan(lat2 / 2 + Math.PI / 4) / Math.Tan(lat1 / 2 + Math.PI / 4));
            var q = Math.Cos(lat1);
            if (dPhi != 0) q = dLat / dPhi;  // E-W line gives dPhi=0
            // if dLon over 180° take shorter rhumb across 180° meridian:
            if (dLon > Math.PI) dLon = 2 * Math.PI - dLon;
            var dist = Math.Sqrt(dLat * dLat + q * q * dLon * dLon) * r;

            return dist;
        }
    }
}
