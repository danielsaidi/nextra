namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate rhumb distance between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IRhumbDistanceCalculator
    {
        double CalculateRhumbDistance(IPosition position1, IPosition position2, DistanceUnit distanceUnit);
    }
}
