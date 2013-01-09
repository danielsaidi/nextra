namespace NExtra.Geo
{
    /// <summary>
    /// This class represents a geographical position.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class Position
    {
        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
