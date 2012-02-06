using System;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class AssemblyExtensionsBehavior
    {
        [Test]
        public void GetCompanyName_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetCompanyName(), Is.EqualTo("Daniel Saidi"));
        }

        [Test]
        public void GetCopyrightHolder_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetCopyrightHolder(), Is.EqualTo("Copyright © Daniel Saidi 2009-2012"));
        }

        [Test]
        public void GetDescription_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetDescription(), Is.EqualTo("Unit tests for NExtra"));
        }

        [Test]
        public void GetNamespaces_ShouldReturnAllNamespaces()
        {
            var result = Assembly.GetExecutingAssembly().GetNamespaces();

            Assert.That(result.Contains("NExtra.Tests"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Validation"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Extensions"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Facades"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Geo"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.IO"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Localization"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Pagination"), Is.True);
        }

        [Test]
        public void GetNamespaceTypes_ShouldReturnAllTypesInNamespace()
        {
            var result = Assembly.GetExecutingAssembly().GetNamespaceTypes("NExtra.Tests").ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.Contains(typeof(EventArgsBehavior)), Is.True);
            Assert.That(result.Contains(typeof(NullableBehavior)), Is.True);
        }

        [Test]
        public void GetProductName_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetProductName(), Is.EqualTo("NExtra"));
        }

        [Test]
        public void GetTitle_ShouldReturnCorrectValueForExistingTitle()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetTitle(), Is.EqualTo("NExtra.Tests"));
        }

        [Test]
        public void GetTitle_ShouldReturnFileNameFOrMissingTitle()
        {
            Assert.That(Assembly.GetCallingAssembly().GetTitle(), Is.EqualTo("nunit.core"));
        }

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

        [Test]
        public void GetVersion_ShouldReturnCorrectValueForExistingTitle()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetVersion(), Is.GreaterThan(new Version(2, 5, 0, 0)));
        }
    }


    public interface MyNonUsedInterface { }
    public interface MyUsedInterface { }
    public class MyParentClass {};
    public class MyChildClass : MyParentClass, MyUsedInterface { }
}