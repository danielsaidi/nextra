namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the distance between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPositionDistanceCalculator
    {
        double CalculateDistance(IPosition pos1, IPosition pos2, DistanceUnit unit);
        double CalculateRhumbDistance(IPosition pos1, IPosition pos2, DistanceUnit unit);
    }
}
