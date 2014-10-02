using System;
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
        private IEnumerable<SomeBaseClass> _descendants;


        [SetUp]
        public void Setup()
        {
            var implementationLocator = new TypeLocator<ISomeInterface>(Assembly.GetExecutingAssembly());
            var descendantLocator = new TypeLocator<SomeBaseClass>(Assembly.GetExecutingAssembly());
            
            _implementations = implementationLocator.FindAll();
            _descendants = descendantLocator.FindAll();
        }


        [Test]
        public void FindAll_ShouldReturnAllImplementationsFromSingleAssembly()
        {
            Assert.That(_implementations.Count(), Is.EqualTo(2));
        }

        [Test]
        public void FindAll_ShouldReturnAllImplementationsWithCorrectTypeFromSingleAssembly()
        {
            Assert.That(_implementations.Any(x => x.GetType() == typeof(SomeClass)), Is.True);
            Assert.That(_implementations.Any(x => x.GetType() == typeof(SomeOtherClass)), Is.True);
        }

        [Test]
        public void FindAll_ShouldReturnAllDescendantsFromSingleAssembly()
        {
            Assert.That(_descendants.Count(), Is.EqualTo(2));
        }

        [Test]
        public void FindAll_ShouldReturnAllDescendantsWithCorrectTypeFromSingleAssembly()
        {
            Assert.That(_descendants.Any(x => x.GetType() == typeof(SomeClass)), Is.True);
            Assert.That(_descendants.Any(x => x.GetType() == typeof(SomeOtherClass)), Is.True);
        }
    }


    internal interface ISomeInterface
    {
        void DoStuff();
    }

    internal abstract class SomeBaseClass
    {
        protected abstract void DoOtherStuff();
    }


    internal class SomeClass : SomeBaseClass, ISomeInterface
    {
        public void DoStuff()
        {}

        protected override void DoOtherStuff()
        {
            throw new NotImplementedException();
        }
    }

    internal class SomeOtherClass : SomeBaseClass, ISomeInterface
    {
        public void DoStuff()
        {}

        protected override void DoOtherStuff()
        {
            throw new NotImplementedException();
        }
    }

}
