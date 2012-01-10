namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the rhumb bearing between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IRhumbBearingCalculator
    {
        /// <summary>
        /// Calculate the rhumb bearing between two positions.
        /// </summary>
        double CalculateRhumbBearing(Position position1, Position position2);
    }
}
