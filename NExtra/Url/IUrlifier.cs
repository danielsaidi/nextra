namespace NExtra.Url
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to urlify objects in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IUrlifier<in T>
    {
        string Urlify(T obj);
    }
}
