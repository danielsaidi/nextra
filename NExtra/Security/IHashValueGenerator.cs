namespace NExtra.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can generate a hash value for any kind of objects.
    /// </summary>
    public interface IHashValueGenerator
    {
        /// <summary>
        /// Generate a hash value for an object.
        /// </summary>
        string GenerateHashValue(object value);
    }
}
