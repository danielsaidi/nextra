namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can convert distance units.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IDistanceConverter
    {
        double ConvertKilometersToMiles(double kilometers);
        double ConvertMilesToKilometers(double miles);
    }
}