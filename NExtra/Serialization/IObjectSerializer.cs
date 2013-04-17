namespace NExtra.Serialization
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to serialize objects. Implementations
    /// could, for instance, use Newtonsoft.Json, to make
    /// it possible to serialize to and from JSON.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IObjectSerializer
    {
        string SerializeObject(object obj);
        string SerializeObject<T>(T obj);
        object DeserializeObject(string objectString);
        T DeserializeObject<T>(string objectString);
    }
}
