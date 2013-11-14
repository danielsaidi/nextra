using System;
using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Object_CloneExtensionsBehavior
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
            var original = new ComplexObject {Name = "Foo" };
            var child = new ComplexObject { Name = "Bar" };
            child.Children.Add(new ComplexObject());
            child.Children.Add(new ComplexObject());
            original.Children.Add(child);

            var copy = original.Clone<ComplexObject>();

            Assert.That(copy.Name, Is.EqualTo("Foo"));
            Assert.That(copy.Children.Count, Is.EqualTo(1));

            Assert.That(copy.Children.First().Name, Is.EqualTo("Bar"));
            Assert.That(copy.Children.First().Children.Count, Is.EqualTo(2));
        }
    }


    [Serializable]
    internal class ComplexObject
    {
        public ComplexObject()
        {
            Children = new List<ComplexObject>();
        }

        public string Name { get; set; }

        public IList<ComplexObject> Children { get; private set; }
    }
}