namespace NExtra.Geo.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the bearing between two positions.
    /// </summary>
    public interface ICanCalculateBearing
    {
        /// <summary>
        /// Calculate the bearing between two positions.
        /// </summary>
        double CalculateBearing(Position position1, Position position2);
    }
}
