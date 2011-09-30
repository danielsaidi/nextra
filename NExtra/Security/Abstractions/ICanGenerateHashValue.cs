namespace NExtra.Security.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that should be able to generate a hash value
    /// for any kind of object.
    /// </summary>
    public interface ICanGenerateHashValue
    {
        /// <summary>
        /// Generate a hash value for an object.
        /// </summary>
        /// <param name="value">The object to create a hash value for.</param>
        /// <returns>The resulting hash value.</returns>
        string GenerateHashValue(object value);
    }
}
