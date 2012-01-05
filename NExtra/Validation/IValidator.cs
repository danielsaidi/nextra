namespace NExtra.Validation
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can be used to validate an object.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IValidator
    {
        bool IsValid(object value);
    }
}
