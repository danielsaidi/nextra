namespace NExtra.Geo
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can calculate the rhumb bearing between two positions.
    /// </summary>
    public interface ICanCalculateRhumbBearing
    {
        /// <summary>
        /// Calculate the rhumb bearing between two positions.
        /// </summary>
        double CalculateRhumbBearing(Position position1, Position position2);
    }
}
