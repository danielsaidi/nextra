namespace NExtra.Abstractions
{
    ///<summary>
    /// This interface can be implemented by classes
    /// that can be used to work towards the Console.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface IConsole
    {
        void Write(string value);
        void WriteLine(string value);
    }
}
