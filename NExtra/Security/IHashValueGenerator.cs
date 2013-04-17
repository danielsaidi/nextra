namespace NExtra.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can generate a hash value for a certain object.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHashValueGenerator
    {
        string GenerateHashValue(object value);
    }
}
