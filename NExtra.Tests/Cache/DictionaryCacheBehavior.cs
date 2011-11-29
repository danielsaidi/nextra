using System;
using System.Collections.Generic;
using System.Text;
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

        public void SetValue(string key, object value)
        {
            cacheManager.Set(key, value);
        }

        public void SetValidValue(string key, object value)
        {
            cacheManager.Set(key, value, new TimeSpan(0, 1, 0, 0));
        }

        public void SetInvalidValue(string key, object value)
        {
            cacheManager.Set(key, value, new TimeSpan(0, -1, 0, 0));
        }

        public void ValueShouldBe<T>(string key, T value)
        {
            Assert.That(cacheManager.Get<T>(key), Is.EqualTo(value));
        }

        public void ValueShouldExist(string key)
        {
            Assert.That(cacheManager.Contains(key), Is.True);
        }

        public void ValueShouldNotExist(string key)
        {
            Assert.That(cacheManager.Contains(key), Is.False);
        }


        [Test]
        public void Clear_ShouldHandleEmptyCache()
        {
            cacheManager.Clear();
        }

        [Test]
        public void Clear_ShouldClearTheEntireCache()
        {
            SetValue("foo", "bar");
            SetValue("bar", "foo");

            ValueShouldExist("foo");
            ValueShouldExist("bar");

            cacheManager.Clear();

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
            cacheManager.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            Assert.That(cacheManager.Contains("foo"), Is.False);
        }

        [Test]
        public void Contains_ShouldReturnTrueForExistingKey()
        {
            cacheManager.Set("foo", "bar");

            Assert.That(cacheManager.Contains("foo"), Is.True);
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForMissingKeyValue()
        {
            cacheManager.Get<string>("foo");
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForInvalidKeyValue()
        {
            cacheManager.Set("foo", "bar", new TimeSpan(0, -1, 0, 0));

            cacheManager.Get<string>("foo");
        }

        [Test]
        public void Get_ShouldReturnExistingKeyValue()
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
        public void Remove_ShouldHandleNonExistingValue()
        {
            cacheManager.Remove("foo");
        }

        [Test]
        public void Remove_ShouldRemoveExistingValue()
        {
            cacheManager.Set("foo", true, new TimeSpan(0, 1, 0, 0));

            Assert.That(cacheManager.Contains("foo"), Is.True);

            cacheManager.Remove("foo");

            Assert.That(cacheManager.Contains("foo"), Is.False);
        }

        [Test]
        [TestCase("foo", true)]
        [TestCase("foo", 3)]
        [TestCase("foo", 7.8)]
        [TestCase("foo", "bar")]
        public void Set_ShouldInsertSimpleValueWithDefaultTimeout(string key, object value)
        {
            cacheManager.Set(key, value);

            Assert.That(cacheManager.Get<object>(key), Is.EqualTo(value));
        }

        [Test]
        public void Set_ShouldInsertComplexValueWithDefaultTimeout()
        {
            var obj = new StringBuilder { Capacity = 1010 };
            cacheManager.Set("foo", obj);
            var cachedObject = cacheManager.Get<StringBuilder>("foo");

            Assert.That(cachedObject, Is.EqualTo(obj));
            Assert.That(cachedObject.Capacity, Is.EqualTo(1010));
        }

        [Test]
        [TestCase("foo", true)]
        [TestCase("foo", 3)]
        [TestCase("foo", 7.8)]
        [TestCase("foo", "bar")]
        public void Set_ShouldInsertSimpleValueWithCustomTimeout(string key, object value)
        {
            cacheManager.Set(key, value, new TimeSpan(0, 1, 0, 0));

            Assert.That(cacheManager.Get<object>(key), Is.EqualTo(value));
        }

        [Test]
        public void Set_ShouldInsertComplexValueWithCustomTimeout()
        {
            var obj = new StringBuilder { Capacity = 1010 };
            cacheManager.Set("foo", obj, new TimeSpan(0, 1, 0, 0));
            var cachedObject = cacheManager.Get<StringBuilder>("foo");

            Assert.That(cachedObject, Is.EqualTo(obj));
            Assert.That(cachedObject.Capacity, Is.EqualTo(1010));
        }

        [Test]
        public void TryGet_ShouldReturnFallbackForMissingKeyValue()
        {
            Assert.That(cacheManager.TryGet("foo", true), Is.True);
            Assert.That(cacheManager.TryGet("foo", 1.8), Is.EqualTo(1.8));
            Assert.That(cacheManager.TryGet("foo", 1), Is.EqualTo(1));
            Assert.That(cacheManager.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }
        [Test]
        public void TryGet_ShouldReturnFallbackForInvalidKeyValue()
        {
            cacheManager.Set("foo", false, new TimeSpan(0, -1, 0, 0));

            Assert.That(cacheManager.TryGet("foo", true), Is.True);

            cacheManager.Set("foo", 1.91, new TimeSpan(0, -1, 0, 0));

            Assert.That(cacheManager.TryGet("foo", 1.8), Is.EqualTo(1.8));

            cacheManager.Set("foo", 4, new TimeSpan(0, -1, 0, 0));

            Assert.That(cacheManager.TryGet("foo", 1), Is.EqualTo(1));

            cacheManager.Set("foo", "foobar", new TimeSpan(0, -1, 0, 0));

            Assert.That(cacheManager.TryGet("foo", "bar"), Is.EqualTo("bar"));
        }

        [Test]
        public void TryGet_ShouldReturnExistingKeyValue()
        {
            cacheManager.Set("foo", true);
            Assert.That(cacheManager.TryGet("foo", false), Is.True);

            cacheManager.Set("foo", 1.8);
            Assert.That(cacheManager.TryGet("foo", 3.6), Is.EqualTo(1.8));

            cacheManager.Set("foo", 2);
            Assert.That(cacheManager.TryGet("foo", 9), Is.EqualTo(2));

            cacheManager.Set("foo", "bar");
            Assert.That(cacheManager.TryGet("foo", "foobar"), Is.EqualTo("bar"));
        }
    }
}