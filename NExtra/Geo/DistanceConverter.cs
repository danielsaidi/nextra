namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to convert distance units.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class DistanceConverter : IDistanceConverter
    {   
        public double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * 0.621371192;
        }

        public double ConvertMilesToKilometers(double miles)
        {
            return miles * 1.609344;
        }
    }
}
