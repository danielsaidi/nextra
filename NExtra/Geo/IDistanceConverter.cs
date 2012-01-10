namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by all classes
    /// that can convert distances in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IDistanceConverter
    {
        /// <summary>
        /// Convert kilometers to miles.
        /// </summary>
        double ConvertKilometersToMiles(double kilometers);

        /// <summary>
        /// Convert miles to kilometers.
        /// </summary>
        double ConvertMilesToKilometers(double miles);
    }
}