using System.Web.Script.Serialization;
using NExtra.Serialization;

namespace NExtra.Web.Serialization
{
    /// <summary>
    /// This class can be used to serialize objects using
    /// the native JavaScriptSerializer class that can be
    /// found in System.Web.Script.Serialization.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class NativeJsonSerializer : IObjectSerializer
    {
        private readonly JavaScriptSerializer serializer;

        
        public NativeJsonSerializer()
        {
            serializer = new JavaScriptSerializer();   
        }

        
        public string SerializeObject(object obj)
        {
            return serializer.Serialize(obj);
        }

        public string SerializeObject<T>(T obj)
        {
            return serializer.Serialize(obj);
        }

        public object DeserializeObject(string objectString)
        {
            return serializer.Deserialize<object>(objectString);
        }

        public T DeserializeObject<T>(string objectString)
        {
            return serializer.Deserialize<T>(objectString);
        }
    }
}
