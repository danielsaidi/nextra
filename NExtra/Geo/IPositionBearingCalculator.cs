namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the bearing between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IPositionBearingCalculator
    {
        double CalculateBearing(IPosition pos1, IPosition pos2);
        double CalculateRhumbBearing(IPosition pos1, IPosition pos2);
    }
}
