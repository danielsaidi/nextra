namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// convert distance units.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
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