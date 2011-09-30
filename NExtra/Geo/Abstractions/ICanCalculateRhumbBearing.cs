namespace NExtra.Geo.Abstractions
{
    /// <summary>
    /// This interface can be implemented by geo classes that
    /// should be able to calculate the rhumb bearing between
    /// two positions.
    /// </summary>
    public interface ICanCalculateRhumbBearing
    {
        /// <summary>
        /// Calculate the rhumb bearing between two positions.
        /// </summary>
        /// <param name="position1">The source position.</param>
        /// <param name="position2">The target position.</param>
        /// <returns>The rhumb bearing between the two positions.</returns>
        double CalculateRhumbBearing(Position position1, Position position2);
    }
}
