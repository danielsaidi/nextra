using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NExtra.Reflection;
using NUnit.Framework;

namespace NExtra.Tests.Reflection
{
    [TestFixture]
    public class TypeLocatorBehavior
    {
        private IEnumerable<ISomeInterface> _implementations;

        [SetUp]
        public void Setup()
        {
            var typeLocator = new TypeLocator<ISomeInterface>(Assembly.GetExecutingAssembly());

            _implementations = typeLocator.FindAll();
        }

        [Test]
        public void FindAll_ShouldReturnAllImplementationsFromSingleAssembly()
        {
            Assert.That(_implementations.Count(), Is.EqualTo(2));
        }
    }

    public interface ISomeInterface
    {
        void DoStuff();
    }

    public class SomeClass : ISomeInterface
    {
        public void DoStuff()
        {}
    }

    public class SomeOtherClass : ISomeInterface
    {
        public void DoStuff()
        {}
    }
}
