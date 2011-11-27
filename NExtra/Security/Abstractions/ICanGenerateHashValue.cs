namespace NExtra.Security.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can generate a hash value for any kind of objects.
    /// </summary>
    public interface ICanGenerateHashValue
    {
        /// <summary>
        /// Generate a hash value for an object.
        /// </summary>
        string GenerateHashValue(object value);
    }
}
