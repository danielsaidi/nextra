namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the rhumb bearing between two positions.
    /// </summary>
    public interface ICanCalculateRhumbDistance
    {
        /// <summary>
        /// Calculate the rhumb distance between two positions.
        /// </summary>
        double CalculateRhumbDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}
