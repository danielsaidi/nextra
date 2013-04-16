namespace NExtra.Geo
{
    /// <summary>
    /// This class represents a geographical position. It
    /// has a latitude and longitude, but no meta data.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class Position : IPosition
    {
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        public double Latitude { get; private set; }

        public double Longitude { get; private set; }
    }
}
