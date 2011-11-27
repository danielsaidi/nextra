namespace NExtra.Geo
{
    /// <summary>
    /// This class can be used to convert distance units.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class DistanceConverter
    {   
        /// <summary>
        /// Convert kilometers to miles.
        /// </summary>
        public double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * 0.621371192;
        }

        /// <summary>
        /// Convert miles to kilometers.
        /// </summary>
        public double ConvertMilesToKilometers(double miles)
        {
            return miles * 1.609344;
        }
    }
}
