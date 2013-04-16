using System;
using System.Linq;
using System.Reflection;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Assembly_ExtensionsBehavior
    {
        [Test]
        public void GetCompanyName_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetCompanyName(), Is.EqualTo("Daniel Saidi"));
        }

        [Test]
        public void GetCopyrightHolder_ShouldReturnCorrectValue()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetCopyrightHolder(), Is.EqualTo("Copyright © Daniel Saidi 2009-2013"));
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
            Assert.That(result.Contains("NExtra.Tests.Geo"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.IO"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Localization"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Pagination"), Is.True);
            Assert.That(result.Contains("NExtra.Tests.Week"), Is.True);
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
        public void GetVersion_ShouldReturnCorrectValueForExistingTitle()
        {
            Assert.That(Assembly.GetExecutingAssembly().GetVersion(), Is.GreaterThan(new Version(2, 5, 0, 0)));
        }
    }
}