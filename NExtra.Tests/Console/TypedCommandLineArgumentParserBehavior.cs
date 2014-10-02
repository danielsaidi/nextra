using System.Collections.Generic;
using NExtra.Console;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Console
{
    [TestFixture]
    public class TypedCommandLineArgumentParserBehavior
    {
        private ICommandLineArgumentParser<CommandLineArguments> _parser;
        private ICommandLineArgumentParser<IDictionary<string, string>> _baseParser;
            
            
        [SetUp]
        public void Setup()
        {
            _baseParser = Substitute.For<ICommandLineArgumentParser<IDictionary<string, string>>>();
            _parser = new TypedCommandLineArgumentParser(_baseParser);
        }


        [Test]
        public void ParseCommandLineArguments_ShouldUseBaseParserToParseArgs()
        {
            var args = new[] { "foo", "bar" };
            _parser.ParseCommandLineArguments(args);

            _baseParser.Received().ParseCommandLineArguments(args);
        }

        [Test]
        public void ParseCommandLineArguments_ShouldReturnBaseParserResult()
        {
            var args = new[] { "foo", "bar" };
            var typedArgs = new Dictionary<string, string>{{"foo", "bar"}, {"bar", "foo"}};
            _baseParser.ParseCommandLineArguments(args).Returns(typedArgs);
            
            var result = _parser.ParseCommandLineArguments(args);

            Assert.That(result.Raw["foo"], Is.EqualTo("bar"));
            Assert.That(result.Raw["bar"], Is.EqualTo("foo"));
        }
    }
}
