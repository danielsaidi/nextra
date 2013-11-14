using System;
using System.Collections.Generic;
using System.Linq;
using NExtra.IO;
using NUnit.Framework;

namespace NExtra.Tests.IO
{
    [TestFixture]
    public class PathPatternMatcherBehavior
    {
        private PathPatternMatcher _pathPatternMatcher;
        private List<string> _exactCollection;
        private List<string> _wildcardCollection;


        [SetUp]
        public void SetUp()
        {
            _pathPatternMatcher = new PathPatternMatcher();
            _exactCollection = new List<string> { "foo", "bar" };
            _wildcardCollection = new List<string> { "*foo", "bar*" };
        }


        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void IsMatch_ShouldFailForNullPath()
        {
            _pathPatternMatcher.IsMatch(null, _exactCollection.First());
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void IsMatch_ShouldFailForNullPattern()
        {
            _pathPatternMatcher.IsMatch("foo", null);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void IsMatch_ShouldReturnFalseForEmptyArguments()
        {
            _pathPatternMatcher.IsMatch("foo", "");
        }

        [Test]
        public void IsMatch_ShouldReturnFalseForExactMismatch()
        {
            Assert.That(_pathPatternMatcher.IsMatch("foot", _exactCollection.First()), Is.False);
        }

        [Test]
        public void IsMatch_ShouldReturnFalseForWildcardMismatches()
        {
            Assert.That(_pathPatternMatcher.IsMatch("foot", _wildcardCollection.First()), Is.False);
        }

        [Test]
        public void IsMatch_ShouldReturnTrueForExactMatch()
        {
            Assert.That(_pathPatternMatcher.IsMatch("foo", _exactCollection.First()), Is.True);
        }

        [Test]
        public void IsMatch_ShouldReturnTrueForWildcardMatches()
        {
            Assert.That(_pathPatternMatcher.IsMatch("afoo", _wildcardCollection.First()), Is.True);
        }


        [Test]
        public void IsAnyMatch_ShouldReturnFalseForNoSpecificedPaths()
        {
            Assert.That(_pathPatternMatcher.IsAnyMatch("foo", new List<string>()), Is.False);
        }

        [Test]
        public void IsAnyMatch_ShouldReturnFalseForExactMismatch()
        {
            Assert.That(_pathPatternMatcher.IsAnyMatch("foot", _exactCollection), Is.False);
            Assert.That(_pathPatternMatcher.IsAnyMatch("bart", _exactCollection), Is.False);
        }

        [Test]
        public void IsAnyMatch_ShouldReturnFalseForWildcardMismatches()
        {
            Assert.That(_pathPatternMatcher.IsAnyMatch("foot", _wildcardCollection), Is.False);
            Assert.That(_pathPatternMatcher.IsAnyMatch("obar", _wildcardCollection), Is.False);
        }

        [Test]
        public void IsAnyMatch_ShouldReturnTrueForExactMatch()
        {
            Assert.That(_pathPatternMatcher.IsAnyMatch("foo", _exactCollection), Is.True);
            Assert.That(_pathPatternMatcher.IsAnyMatch("bar", _exactCollection), Is.True);
        }

        [Test]
        public void IsAnyMatch_ShouldReturnTrueForWildcardMatches()
        {
            Assert.That(_pathPatternMatcher.IsAnyMatch("afoo", _wildcardCollection), Is.True);
            Assert.That(_pathPatternMatcher.IsAnyMatch("bara", _wildcardCollection), Is.True);
        }
    }
}
