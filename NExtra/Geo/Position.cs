namespace NExtra.Geo
{
    /// <summary>
    /// This class represents a position with a latitude and longitude.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Position
    {
        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        /// <param name="latitude">The position latitude.</param>
        /// <param name="longitude">The position longitude.</param>
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        /// <summary>
        /// The position latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The position longitude.
        /// </summary>
        public double Longitude { get; set; }
    }
}
