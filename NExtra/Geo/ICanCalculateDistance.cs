namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the distance between two positions.
    /// </summary>
    public interface ICanCalculateDistance
    {
        /// <summary>
        /// Calculate the distance between two positions.
        /// </summary>
        double CalculateDistance(Position position1, Position position2, DistanceUnit distanceUnit);
    }
}
