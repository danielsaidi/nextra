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
        private readonly IAngleConverter angleConverter;


        public PositionDistanceCalculator(IAngleConverter angleConverter)
        {
            this.angleConverter = angleConverter;
            this.angleConverter = angleConverter;
        }


        public double CalculatePositionDistance(IPosition position1, IPosition position2, DistanceUnit distanceUnit)
        {
            var R = (distanceUnit == DistanceUnit.Miles) ? GeoConstants.EarthRadiusInMiles : GeoConstants.EarthRadiusInKilometers;
            var dLat = angleConverter.ConvertDegreesToRadians(position2.Latitude) - angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(position2.Longitude) - angleConverter.ConvertDegreesToRadians(position1.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(angleConverter.ConvertDegreesToRadians(position1.Latitude)) * Math.Cos(angleConverter.ConvertDegreesToRadians(position2.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = c * R;

            return Math.Round(distance, 2);
        }

        public double CalculatePositionRhumbDistance(IPosition position1, IPosition position2, DistanceUnit distanceUnit)
        {
            var R = (distanceUnit == DistanceUnit.Miles) ? GeoConstants.EarthRadiusInMiles : GeoConstants.EarthRadiusInKilometers;
            var lat1 = angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var lat2 = angleConverter.ConvertDegreesToRadians(position2.Latitude);
            var dLat = angleConverter.ConvertDegreesToRadians(position2.Latitude - position1.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(Math.Abs(position2.Longitude - position1.Longitude));

            var dPhi = Math.Log(Math.Tan(lat2 / 2 + Math.PI / 4) / Math.Tan(lat1 / 2 + Math.PI / 4));
            var q = Math.Cos(lat1);
            if (dPhi != 0) q = dLat / dPhi;  // E-W line gives dPhi=0
            // if dLon over 180° take shorter rhumb across 180° meridian:
            if (dLon > Math.PI) dLon = 2 * Math.PI - dLon;
            var dist = Math.Sqrt(dLat * dLat + q * q * dLon * dLon) * R;

            return dist;
        }
    }
}