using System.Collections.Generic;
using NExtra.Cache;
using NExtra.Cache.Abstractions;
using NUnit.Framework;

namespace NExtra.Tests.Cache
{
    [TestFixture]
    public class DictionaryCacheBehavior
    {
        private ICacheManager cacheManager;


        [SetUp]
        public void SetUp()
        {
            cacheManager = new DictionaryCache();
        }


        [Test]
        public void Clear_ShouldHandleEmptyCache()
        {
            cacheManager.Clear();
        }

        [Test]
        public void Clear_ShouldClearTheEntireCache()
        {
            cacheManager.Set("foo", "bar");
            cacheManager.Set("bar", "foo");

            Assert.That(cacheManager.Contains("foo"), Is.True);
            Assert.That(cacheManager.Contains("bar"), Is.True);

            cacheManager.Clear();

            Assert.That(cacheManager.Contains("foo"), Is.False);
            Assert.That(cacheManager.Contains("bar"), Is.False);
        }

        [Test]
        public void Contains_ShouldReturnFalseForNonExistingKey()
        {
            Assert.That(cacheManager.Contains("foo"), Is.False);
        }

        [Test]
        public void Contains_ShouldReturnTrueForExistingKey()
        {
            cacheManager.Set("foo", "bar");

            Assert.That(cacheManager.Contains("foo"), Is.True);
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void GetWithoutFallback_ShouldFailForMissingKeyValue()
        {
            Assert.That(cacheManager.Get<string>("foo"), Is.Null);
        }

        [Test]
        public void GetWithoutFallback_ShouldReturnExistingKeyValue()
        {
            cacheManager.Set("foo", true);
            Assert.That(cacheManager.Get<bool>("foo"), Is.True);

            cacheManager.Set("foo", 1.8);
            Assert.That(cacheManager.Get<double>("foo"), Is.EqualTo(1.8));

            cacheManager.Set("foo", 1);
            Assert.That(cacheManager.Get<int>("foo"), Is.EqualTo(1));

            cacheManager.Set("foo", "bar");
            Assert.That(cacheManager.Get<string>("foo"), Is.EqualTo("bar"));
        }

        [Test]
        public void GetWithFallback_ShouldReturnFallbackForMissingKeyValue()
        {
            Assert.That(cacheManager.Get("foo", true), Is.True);
            Assert.That(cacheManager.Get("foo", 1.8), Is.EqualTo(1.8));
            Assert.That(cacheManager.Get("foo", 1), Is.EqualTo(1));
            Assert.That(cacheManager.Get("foo", "bar"), Is.EqualTo("bar"));
        }

        [Test]
        public void GetWithFallback_ShouldReturnExistingKeyValue()
        {
            cacheManager.Set("foo", true);
            Assert.That(cacheManager.Get("foo", false), Is.True);

            cacheManager.Set("foo", 1.8);
            Assert.That(cacheManager.Get("foo", 3.6), Is.EqualTo(1.8));

            cacheManager.Set("foo", 2);
            Assert.That(cacheManager.Get("foo", 9), Is.EqualTo(2));

            cacheManager.Set("foo", "bar");
            Assert.That(cacheManager.Get("foo", "foobar"), Is.EqualTo("bar"));
        }
    }
}