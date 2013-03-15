using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using NExtra.Serialization;

namespace NExtra.Web.Serialization
{
    /// <summary>
    /// This class can be used to serialize objects using the 
    /// System.Web.Script.Serialization.JavaScriptSerializer.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class NativeJsonSerializer : IObjectSerializer
    {
        private JavaScriptSerializer serializer;


        /// <summary>
        /// Create an instance of the class.
        /// </summary>
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
            throw new NotImplementedException();
        }

        public object DeserializeObject(string objectString)
        {
            throw new NotImplementedException();
        }

        public T DeserializeObject<T>(string objectString)
        {
            throw new NotImplementedException();
        }
    }
}
