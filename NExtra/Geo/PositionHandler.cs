using System;

namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to calculate the distance
    /// and bearing between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// Link:       http://myxaab.wordpress.com/2010/09/02/calculate-distance-bearing-between-geolocation/
    /// </remarks>
    public class PositionHandler : IBearingCalculator, IDistanceCalculator, IRhumbBearingCalculator, IRhumbDistanceCalculator
    {
        private readonly AngleConverter angleConverter;

        
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public PositionHandler()
        {
            angleConverter = new AngleConverter();
        }


        /// <summary>
        /// Calculate the bearing between two positions.
        /// </summary>
        public double CalculateBearing(Position position1, Position position2)
        {
            var lat1 = angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var lat2 = angleConverter.ConvertDegreesToRadians(position2.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(position2.Longitude) - angleConverter.ConvertDegreesToRadians(position1.Longitude);

            var y = Math.Sin(dLon) * Math.Cos(lat2);
            var x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(dLon);
            var brng = Math.Atan2(y, x);

            return (angleConverter.ConvertRadiansToDegrees(brng) + 360) % 360;
        }

        /// <summary>
        /// Calculate the distance between two positions.
        /// </summary>
        public double CalculateDistance(Position position1, Position position2, DistanceUnit distanceUnit)
        {
            var R = (distanceUnit == DistanceUnit.Miles) ? GeoConstants.EarthRadiusInMiles : GeoConstants.EarthRadiusInKilometers;
            var dLat = angleConverter.ConvertDegreesToRadians(position2.Latitude) - angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(position2.Longitude) - angleConverter.ConvertDegreesToRadians(position1.Longitude);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(angleConverter.ConvertDegreesToRadians(position1.Latitude)) * Math.Cos(angleConverter.ConvertDegreesToRadians(position2.Latitude)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = c * R;

            return Math.Round(distance, 2);
        }

        /// <summary>
        /// Calculate the rhumb bearing between two positions.
        /// </summary>
        public double CalculateRhumbBearing(Position position1, Position position2)
        {
            var lat1 = angleConverter.ConvertDegreesToRadians(position1.Latitude);
            var lat2 = angleConverter.ConvertDegreesToRadians(position2.Latitude);
            var dLon = angleConverter.ConvertDegreesToRadians(position2.Longitude - position1.Longitude);

            var dPhi = Math.Log(Math.Tan(lat2 / 2 + Math.PI / 4) / Math.Tan(lat1 / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI) dLon = (dLon > 0) ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            var brng = Math.Atan2(dLon, dPhi);

            return (angleConverter.ConvertRadiansToDegrees(brng) + 360) % 360;
        }

        /// <summary>
        /// Calculate the rhumb distance between two positions.
        /// </summary>
        public double CalculateRhumbDistance(Position position1, Position position2, DistanceUnit distanceUnit)
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
