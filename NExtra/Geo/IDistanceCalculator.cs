namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the distance between two positions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculate the distance between two positions.
        /// </summary>
        double CalculateDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}
