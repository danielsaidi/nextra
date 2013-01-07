namespace NExtra.Validation
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can be used to validate an object.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IValidator
    {
        bool IsValid(object value);
    }
}
