namespace NExtra.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can generate a hash value for any kind of objects.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IHashValueGenerator
    {
        /// <summary>
        /// Generate a hash value for an object.
        /// </summary>
        string GenerateHashValue(object value);
    }
}
