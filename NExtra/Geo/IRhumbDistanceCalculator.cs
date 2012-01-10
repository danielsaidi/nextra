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
    public interface IRhumbDistanceCalculator
    {
        /// <summary>
        /// Calculate the rhumb distance between two positions.
        /// </summary>
        double CalculateRhumbDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}
