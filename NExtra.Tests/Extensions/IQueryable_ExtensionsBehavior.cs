using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
	[TestFixture]
	public class IQueryable_ExtensionsBehavior
	{
        private List<KeyValuePair<string, int>> collection;
        private List<KeyValuePair<string, int>> magazineSales;


		[SetUp]
		public void SetUp()
		{
			collection = new List<KeyValuePair<string, int>> {
				new KeyValuePair<string, int>("a", 99),
				new KeyValuePair<string, int>("b", 98),
				new KeyValuePair<string, int>("c", 97),
				new KeyValuePair<string, int>("d", 96),
				new KeyValuePair<string, int>("e", 95)
			};
            
            magazineSales = new List<KeyValuePair<string, int>> {
                new KeyValuePair<string, int>("DN", 5),
                new KeyValuePair<string, int>("SvD", 5),
                new KeyValuePair<string, int>("DN", 1),
                new KeyValuePair<string, int>("SvD", 1)
            };
		}


        [Test]
        public void OrderBy_ShouldApplyToCollection()
        {
            var original = magazineSales;
            var result = magazineSales.AsQueryable().OrderBy("Key").ToList();

            Assert.That(result[0], Is.EqualTo(original[0]));
            Assert.That(result[1], Is.EqualTo(original[2]));
            Assert.That(result[2], Is.EqualTo(original[1]));
            Assert.That(result[3], Is.EqualTo(original[3]));
        }

        [Test]
        public void OrderBy_ShouldOverrideLastOrderBy()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderBy("Key").OrderBy("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[2]));
            Assert.That(result[1], Is.EqualTo(original[3]));
            Assert.That(result[2], Is.EqualTo(original[0]));
            Assert.That(result[3], Is.EqualTo(original[1]));
        }

        [Test]
        public void OrderByDescending_ShouldApplyToCollection()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderByDescending("Key").ToList();

            Assert.That(result[0], Is.EqualTo(original[1]));
            Assert.That(result[1], Is.EqualTo(original[3]));
            Assert.That(result[2], Is.EqualTo(original[0]));
            Assert.That(result[3], Is.EqualTo(original[2]));
        }

        [Test]
        public void OrderByDescending_ShouldOverrideLastOrderByDescending()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderByDescending("Key").OrderByDescending("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[1]));
            Assert.That(result[1], Is.EqualTo(original[0]));
            Assert.That(result[2], Is.EqualTo(original[3]));
            Assert.That(result[3], Is.EqualTo(original[2]));
        }

		[Test]
		public void Result_ShouldHandleFirstItems()
		{
			var result = collection.AsQueryable().Paginate(1, 2);

			Assert.That(result.Count(), Is.EqualTo(2));
			Assert.That(result, Is.EqualTo(collection.Skip(0).Take(2)));
		}

		[Test]
		public void Result_ShouldHandleMiddleItems()
		{
			var result = collection.AsQueryable().Paginate(2, 2);

			Assert.That(result.Count(), Is.EqualTo(2));
			Assert.That(result, Is.EqualTo(collection.Skip(2).Take(2)));
		}

		[Test]
		public void Result_ShouldHandleLastItems()
		{
			var result = collection.AsQueryable().Paginate(3, 2);

			Assert.That(result.Count(), Is.EqualTo(1));
			Assert.That(result, Is.EqualTo(collection.Skip(4).Take(2)));
        }

        [Test]
        public void ThenBy_ShouldCompleteLastOrderBy()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderBy("Key").ThenBy("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[2]));
            Assert.That(result[1], Is.EqualTo(original[0]));
            Assert.That(result[2], Is.EqualTo(original[3]));
            Assert.That(result[3], Is.EqualTo(original[1]));
        }

        [Test]
        public void ThenBy_ShouldCompleteLastOrderByDescending()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderByDescending("Key").ThenBy("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[3]));
            Assert.That(result[1], Is.EqualTo(original[1]));
            Assert.That(result[2], Is.EqualTo(original[2]));
            Assert.That(result[3], Is.EqualTo(original[0]));
        }

        [Test]
        public void ThenByDescending_ShouldCompleteLastOrderBy()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderBy("Key").ThenByDescending("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[0]));
            Assert.That(result[1], Is.EqualTo(original[2]));
            Assert.That(result[2], Is.EqualTo(original[1]));
            Assert.That(result[3], Is.EqualTo(original[3]));
        }

        [Test]
        public void ThenByDescending_ShouldCompleteLastOrderByDescending()
        {
            var original = magazineSales.ToList();
            var result = magazineSales.AsQueryable().OrderByDescending("Key").ThenByDescending("Value").ToList();

            Assert.That(result[0], Is.EqualTo(original[1]));
            Assert.That(result[1], Is.EqualTo(original[3]));
            Assert.That(result[2], Is.EqualTo(original[0]));
            Assert.That(result[3], Is.EqualTo(original[2]));
        }
	}
}
