using System;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Assembly_TypeExtensionsBehavior
    {
        [Test]
        public void GetTypesThatInherit_SingleAssembly_ShouldReturnZeroForNoDescendants()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatInherit(typeof(MyChildClass));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatInherit_SingleAssembly_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatInherit(typeof(MyParentClass)).ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }

        [Test]
        public void GetTypesThatInherit_MultipleAssemblies_ShouldReturnZeroForNoDescendants()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatInherit(typeof(MyChildClass));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatInherit_MultipleAssemblies_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatInherit(typeof(MyParentClass)).ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }

        [Test]
        public void GetTypesThatImplement_SingleAssembly_ShouldReturnZeroForNoImplementors()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatImplement(typeof(IMyNonUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatImplement_SingleAssembly_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatImplement(typeof(IMyUsedInterface)).ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }

        [Test]
        public void GetTypesThatImplement_MultipleAssemblies_ShouldReturnZeroForNoImplementors()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatImplement(typeof(IMyNonUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatImplement_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatImplement(typeof(IMyUsedInterface)).ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }
    }


    public interface IMyNonUsedInterface { }
    public interface IMyUsedInterface { }
    public class MyParentClass {};
    public class MyChildClass : MyParentClass, IMyUsedInterface { }
}