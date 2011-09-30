namespace NExtra.Geo.Abstractions
{
    /// <summary>
    /// This interface can be implemented by geo classes that
    /// should be able to calculate bearing between positions.
    /// </summary>
    public interface ICanCalculateBearing
    {
        /// <summary>
        /// Calculate the bearing between two positions.
        /// </summary>
        /// <param name="position1">The source position.</param>
        /// <param name="position2">The target position.</param>
        /// <returns>The bearing between the two positions.</returns>
        double CalculateBearing(Position position1, Position position2);
    }
}
