namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can convert angular values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAngleConverter
    {
        double ConvertDegreesToRadians(double degrees);
        double ConvertRadiansToDegrees(double radians);
    }
}