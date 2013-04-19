using NExtra.Serialization;
using NExtra.Web.Serialization;
using NUnit.Framework;

namespace NExtra.Web.Tests.Serialization
{
    [TestFixture]
    public class NativeJsonSerializerTests
    {
        private IObjectSerializer serializer;


        [SetUp]
        public void Setup()
        {
            serializer = new NativeJsonSerializer();
        }


        [Test]
        public void SerializeObject_ShouldHandleInt()
        {
            Assert.That(serializer.SerializeObject(1), Is.EqualTo("1"));
        }

        [Test]
        public void SerializeObject_ShouldHandleBool()
        {
            Assert.That(serializer.SerializeObject(true), Is.EqualTo("true"));
        }

        [Test]
        public void SerializeObject_ShouldHandleString()
        {
            Assert.That(serializer.SerializeObject("foo"), Is.EqualTo("\"foo\""));
        }

        [Test]
        public void SerializeObject_ShouldHandleType()
        {
            var user = new SerializerTest { FirstName = "Daniel", LastName = "Saidi" };
            var userString = serializer.SerializeObject(user);

            Assert.That(userString, Is.EqualTo("{\"FirstName\":\"Daniel\",\"LastName\":\"Saidi\"}"));
        }


        [Test]
        public void DeserializeObject_ShouldHandleInt()
        {
            Assert.That(serializer.DeserializeObject("1"), Is.EqualTo(1));
        }

        [Test]
        public void DeserializeObject_ShouldHandleBool()
        {
            Assert.That(serializer.DeserializeObject("true"), Is.EqualTo(true));
        }

        [Test]
        public void DeserializeObject_ShouldHandleString()
        {
            Assert.That(serializer.DeserializeObject("\"foo\""), Is.EqualTo("foo"));
        }

        [Test]
        public void DeserializeObject_ShouldHandleType()
        {
            var user = new SerializerTest { FirstName = "Daniel", LastName = "Saidi" };
            var userString = serializer.SerializeObject(user);
            var deserialized = serializer.DeserializeObject<SerializerTest>(userString);

            Assert.That(deserialized.FirstName, Is.EqualTo("Daniel"));
            Assert.That(deserialized.LastName, Is.EqualTo("Saidi"));
        }
    }


    internal class SerializerTest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
