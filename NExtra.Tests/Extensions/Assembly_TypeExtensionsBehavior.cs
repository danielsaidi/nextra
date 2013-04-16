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
            var result = Assembly.GetExecutingAssembly().GetTypesThatInherit(typeof(MyParentClass));

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
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatInherit(typeof(MyParentClass));

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }

        [Test]
        public void GetTypesThatImplement_SingleAssembly_ShouldReturnZeroForNoImplementors()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatImplement(typeof(MyNonUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatImplement_SingleAssembly_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = Assembly.GetExecutingAssembly().GetTypesThatImplement(typeof(MyUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }

        [Test]
        public void GetTypesThatImplement_MultipleAssemblies_ShouldReturnZeroForNoImplementors()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatImplement(typeof(MyNonUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GetTypesThatImplement_ShouldReturnCorrectNumberForNoDescendants()
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().GetTypesThatImplement(typeof(MyUsedInterface));

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(typeof(MyChildClass)));
        }
    }


    public interface MyNonUsedInterface { }
    public interface MyUsedInterface { }
    public class MyParentClass {};
    public class MyChildClass : MyParentClass, MyUsedInterface { }
}