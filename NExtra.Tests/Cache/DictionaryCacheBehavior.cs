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
        private ICache _cache;


        [SetUp]
        public void SetUp()
        {
            _cache = new DictionaryCache();
        }

        public void SetValidValue(string key, object value)
        {
            _cache.Set(key, value, new TimeSpan(0, 1, 0, 0));
        }

        public void SetInvalidValue(string key, object value)
        {
            _cache.Set(key, value, new TimeSpan(0, -1, 0, 0));
        }

        public void ValueShouldBe<T>(string key, T value)
        {
            Assert.That(_cache.Get<T>(key), Is.EqualTo(value));
        }

        public void ValueShouldExist(string key)
        {
            Assert.That(_cache.Contains(key), Is.True);
        }

        public void ValueShouldNotExist(string key)
        {
            Assert.That(_cache.Contains(key), Is.False);
        }


        [Test]
        public void Clear_ShouldHandleEmptyCache()
        {
            _cache.Clear();
        }

        [Test]
        public void Clear_ShouldClearTheEntireCache()
        {
            _cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            _cache.Set("bar", "foo", new TimeSpan(0, 1, 0, 0));

            ValueShouldExist("foo");
            ValueShouldExist("bar");

            _cache.Clear();

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
            _cache.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            Assert.That(_cache.Contains("foo"), Is.False);
        }

        [Test]
        public void Contains_ShouldReturnTrueForExistingKey()
        {
            _cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));

            Assert.That(_cache.Contains("foo"), Is.True);
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForMissingKeyValue()
        {
            _cache.Get<string>("foo");
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForInvalidKeyValue()
        {
            _cache.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            _cache.Get<string>("foo");
        }

        [Test]
        public void Get_ShouldReturnExistingKeyValue()
        {
            _cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.Get<bool>("foo"), Is.True);

            _cache.Set("foo", 1.8, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.Get<double>("foo"), Is.EqualTo(1.8));

            _cache.Set("foo", 1, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.Get<int>("foo"), Is.EqualTo(1));

            _cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.Get<string>("foo"), Is.EqualTo("bar"));
        }

        [Test]
        public void Remove_ShouldHandleNonExistingValue()
        {
            _cache.Remove("foo");
        }

        [Test]
        public void Remove_ShouldRemoveExistingValue()
        {
            _cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));

            Assert.That(_cache.Contains("foo"), Is.True);

            _cache.Remove("foo");

            Assert.That(_cache.Contains("foo"), Is.False);
        }

        [Test]
        [TestCase("foo", true)]
        [TestCase("foo", 3)]
        [TestCase("foo", 7.8)]
        [TestCase("foo", "bar")]
        public void Set_ShouldInsertSimpleValue(string key, object value)
        {
            _cache.Set(key, value, new TimeSpan(0, 1, 0, 0));

            Assert.That(_cache.Get<object>(key), Is.EqualTo(value));
        }

        [Test]
        public void Set_ShouldInsertComplexValue()
        {
            var obj = new StringBuilder { Capacity = 1010 };
            _cache.Set("foo", obj, new TimeSpan(0, 1, 0, 0));
            var cachedObject = _cache.Get<StringBuilder>("foo");

            Assert.That(cachedObject, Is.EqualTo(obj));
            Assert.That(cachedObject.Capacity, Is.EqualTo(1010));
        }

        [Test]
        public void TryGet_ShouldReturnFallbackForMissingKeyValue()
        {
            Assert.That(_cache.TryGet("foo", true), Is.True);
            Assert.That(_cache.TryGet("foo", 1.8), Is.EqualTo(1.8));
            Assert.That(_cache.TryGet("foo", 1), Is.EqualTo(1));
            Assert.That(_cache.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }
        [Test]
        public void TryGet_ShouldReturnFallbackForInvalidKeyValue()
        {
            _cache.Set("foo", false, new TimeSpan(0, -1, 0, 0));

            Assert.That(_cache.TryGet("foo", true), Is.True);

            _cache.Set("foo", 1.91, new TimeSpan(0, -1, 0, 0));

            Assert.That(_cache.TryGet("foo", 1.8), Is.EqualTo(1.8));

            _cache.Set("foo", 4, new TimeSpan(0, -1, 0, 0));

            Assert.That(_cache.TryGet("foo", 1), Is.EqualTo(1));

            _cache.Set("foo", "foobar", new TimeSpan(0, -1, 0, 0));

            Assert.That(_cache.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }

        [Test]
        public void TryGet_ShouldReturnExistingKeyValue()
        {
            _cache.Set("foo", true, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.TryGet("foo", false), Is.True);

            _cache.Set("foo", 1.8, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.TryGet("foo", 3.6), Is.EqualTo(1.8));

            _cache.Set("foo", 2, new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.TryGet("foo", 9), Is.EqualTo(2));

            _cache.Set("foo", "bar", new TimeSpan(0, 1, 0, 0));
            Assert.That(_cache.TryGet("foo", "foobar"), Is.EqualTo("bar"));
        }
    }
}