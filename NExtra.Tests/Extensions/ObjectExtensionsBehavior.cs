using System;
using System.Collections.Generic;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class ObjectExtensionsBehavior
    {
        [Test, ExpectedException(typeof(InvalidCastException))]
        public void Clone_ShouldFailForInvalidCast()
        {
            const double original = 1.2;
            var copy = original.Clone<string>();

            Assert.That(copy, Is.EqualTo("foo"));
        }

        [Test]
        public void Clone_ShouldCloneString()
        {
            const string original = "foo";
            var copy = original.Clone<string>();

            Assert.That(copy, Is.EqualTo("foo"));
        }

        [Test]
        public void Clone_ShouldCloneNumeric()
        {
            const double original = 1.2;
            var copy = original.Clone<double>();

            Assert.That(copy, Is.EqualTo(1.2));
        }

        [Test]
        public void Clone_ShouldCloneBoolean()
        {
            const bool original = true;
            var copy = original.Clone<bool>();

            Assert.That(copy, Is.EqualTo(true));
        }

        [Test]
        public void Clone_ShouldCloneKeyValuePair()
        {
            var original = new KeyValuePair<int, string>(1, "foo");
            var copy = original.Clone<KeyValuePair<int, string>>();

            Assert.That(copy.Key, Is.EqualTo(1));
            Assert.That(copy.Value, Is.EqualTo("foo"));
        }

        [Test]
        public void Clone_ShouldCloneComplexObject()
        {
            var original = new ComplexObject {Name = "Foo", Children = new List<ComplexObject>() };
            original.Children.Add(new ComplexObject { Name = "Bar", Children = new List<ComplexObject>{new ComplexObject(), new ComplexObject()}});

            var copy = original.Clone<ComplexObject>();

            Assert.That(copy.Name, Is.EqualTo("Foo"));
            Assert.That(copy.Children.Count, Is.EqualTo(1));

            Assert.That(copy.Children[0].Name, Is.EqualTo("Bar"));
            Assert.That(copy.Children[0].Children.Count, Is.EqualTo(2));
        }
    }


    [Serializable]
    class ComplexObject
    {
        public string Name { get; set; }

        public List<ComplexObject> Children { get; set; }
    }
}