using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.object.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class Object_CloneExtensions
    {
        /// <summary>
        /// Clone a serializable object to a copy.
        /// </summary>
        public static object Clone(this object original)
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();

            formatter.Serialize(stream, original);
            stream.Seek(0, SeekOrigin.Begin);

            var result = formatter.Deserialize(stream);
            stream.Close();

            return result;
        }

        /// <summary>
        /// Clone a serializable object to a copy of the same type.
        /// </summary>
        public static T Clone<T>(this object original)
        {
            if (original == null)
                return default(T);

            return (T) original.Clone();
        }
    }
}
