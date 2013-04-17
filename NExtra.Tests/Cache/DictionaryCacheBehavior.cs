using System;
using System.Collections.Generic;
using System.Text;
using NExtra.Cache;
using NUnit.Framework;

namespace NExtra.Tests.Cache
{
    [TestFixture]
    public class DictionaryCacheBehavior
    {
        private ICache cache;


        [SetUp]
        public void SetUp()
        {
            cache = new DictionaryCache();
        }

        public void SetValidValue(string key, object value)
        {
            cache.Set(key, value, new TimeSpan(0, 1, 0, 0));
        }

        public void SetInvalidValue(string key, object value)
        {
            cache.Set(key, value, new TimeSpan(0, -1, 0, 0));
        }

        public void ValueShouldBe<T>(string key, T value)
        {
            Assert.That(cache.Get<T>(key), Is.EqualTo(value));
        }

        public void ValueShouldExist(string key)
        {
            Assert.That(cache.Contains(key), Is.True);
        }

        public void ValueShouldNotExist(string key)
        {
            Assert.That(cache.Contains(key), Is.False);
        }


        [Test]
        public void Clear_ShouldHandleEmptyCache()
        {
            cache.Clear();
        }

        [Test]
        public void Clear_ShouldClearTheEntireCache()
        {
            cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            cache.Set("bar", "foo", new TimeSpan(0, 1, 0, 0));

            ValueShouldExist("foo");
            ValueShouldExist("bar");

            cache.Clear();

            ValueShouldNotExist("foo");
            ValueShouldNotExist("bar");
        }

        [Test]
        public void Contains_ShouldReturnFalseForNonExistingKey()
        {
            ValueShouldNotExist("foo");
        }

        [Test]
        public void Contains_ShouldReturnFalseForInvalidKey()
        {
            cache.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            Assert.That(cache.Contains("foo"), Is.False);
        }

        [Test]
        public void Contains_ShouldReturnTrueForExistingKey()
        {
            cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));

            Assert.That(cache.Contains("foo"), Is.True);
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForMissingKeyValue()
        {
            cache.Get<string>("foo");
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForInvalidKeyValue()
        {
            cache.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            cache.Get<string>("foo");
        }

        [Test]
        public void Get_ShouldReturnExistingKeyValue()
        {
            cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.Get<bool>("foo"), Is.True);

            cache.Set("foo", 1.8, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.Get<double>("foo"), Is.EqualTo(1.8));

            cache.Set("foo", 1, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.Get<int>("foo"), Is.EqualTo(1));

            cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.Get<string>("foo"), Is.EqualTo("bar"));
        }

        [Test]
        public void Remove_ShouldHandleNonExistingValue()
        {
            cache.Remove("foo");
        }

        [Test]
        public void Remove_ShouldRemoveExistingValue()
        {
            cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));

            Assert.That(cache.Contains("foo"), Is.True);

            cache.Remove("foo");

            Assert.That(cache.Contains("foo"), Is.False);
        }

        [Test]
        [TestCase("foo", true)]
        [TestCase("foo", 3)]
        [TestCase("foo", 7.8)]
        [TestCase("foo", "bar")]
        public void Set_ShouldInsertSimpleValue(string key, object value)
        {
            cache.Set(key, value, new TimeSpan(0, 1, 0, 0));

            Assert.That(cache.Get<object>(key), Is.EqualTo(value));
        }

        [Test]
        public void Set_ShouldInsertComplexValue()
        {
            var obj = new StringBuilder { Capacity = 1010 };
            cache.Set("foo", obj, new TimeSpan(0, 1, 0, 0));
            var cachedObject = cache.Get<StringBuilder>("foo");

            Assert.That(cachedObject, Is.EqualTo(obj));
            Assert.That(cachedObject.Capacity, Is.EqualTo(1010));
        }

        [Test]
        public void TryGet_ShouldReturnFallbackForMissingKeyValue()
        {
            Assert.That(cache.TryGet("foo", true), Is.True);
            Assert.That(cache.TryGet("foo", 1.8), Is.EqualTo(1.8));
            Assert.That(cache.TryGet("foo", 1), Is.EqualTo(1));
            Assert.That(cache.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }
        [Test]
        public void TryGet_ShouldReturnFallbackForInvalidKeyValue()
        {
            cache.Set("foo", false, new TimeSpan(0, -1, 0, 0));

            Assert.That(cache.TryGet("foo", true), Is.True);

            cache.Set("foo", 1.91, new TimeSpan(0, -1, 0, 0));

            Assert.That(cache.TryGet("foo", 1.8), Is.EqualTo(1.8));

            cache.Set("foo", 4, new TimeSpan(0, -1, 0, 0));

            Assert.That(cache.TryGet("foo", 1), Is.EqualTo(1));

            cache.Set("foo", "foobar", new TimeSpan(0, -1, 0, 0));

            Assert.That(cache.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }

        [Test]
        public void TryGet_ShouldReturnExistingKeyValue()
        {
            cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.TryGet("foo", false), Is.True);

            cache.Set("foo", 1.8, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.TryGet("foo", 3.6), Is.EqualTo(1.8));

            cache.Set("foo", 2, new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.TryGet("foo", 9), Is.EqualTo(2));

            cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            Assert.That(cache.TryGet("foo", "foobar"), Is.EqualTo("bar"));
        }
    }
}