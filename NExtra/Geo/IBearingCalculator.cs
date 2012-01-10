namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the bearing between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IBearingCalculator
    {
        /// <summary>
        /// Calculate the bearing between two positions.
        /// </summary>
        double CalculateBearing(Position position1, Position position2);
    }
}
