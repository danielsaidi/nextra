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
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        /// <summary>
        /// The latitude of the position.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude of the position.
        /// </summary>
        public double Longitude { get; set; }
    }
}
