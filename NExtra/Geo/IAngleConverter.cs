namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// convert angular values.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAngleConverter
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        double ConvertDegreesToRadians(double degrees);

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        double ConvertRadiansToDegrees(double radians);
    }
}