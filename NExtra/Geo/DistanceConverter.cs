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
        /// <param name="kilometers">The distance, in kilometers.</param>
        /// <returns>The distance, in miles.</returns>
        public double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * 0.621371192;
        }

        /// <summary>
        /// Convert miles to kilometers.
        /// </summary>
        /// <param name="miles">The distance, in miles.</param>
        /// <returns>The distance, in kilometers.</returns>
        public double ConvertMilesToKilometers(double miles)
        {
            return miles * 1.609344;
        }
    }
}
