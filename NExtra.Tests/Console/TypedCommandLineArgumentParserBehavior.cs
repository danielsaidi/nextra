using System.Collections.Generic;
using NExtra.Console;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Tests.Console
{
    [TestFixture]
    public class TypedCommandLineArgumentParserBehavior
    {
        private ICommandLineArgumentParser<CommandLineArguments> parser;
        private ICommandLineArgumentParser<IDictionary<string, string>> baseParser;
            
            
        [SetUp]
        public void Setup()
        {
            baseParser = Substitute.For<ICommandLineArgumentParser<IDictionary<string, string>>>();
            parser = new TypedCommandLineArgumentParser(baseParser);
        }


        [Test]
        public void ParseCommandLineArguments_ShouldUseBaseParserToParseArgs()
        {
            var args = new[] { "foo", "bar" };
            parser.ParseCommandLineArguments(args);

            baseParser.Received().ParseCommandLineArguments(args);
        }

        [Test]
        public void ParseCommandLineArguments_ShouldReturnBaseParserResult()
        {
            var args = new[] { "foo", "bar" };
            var typedArgs = new Dictionary<string, string>{{"foo", "bar"}, {"bar", "foo"}};
            baseParser.ParseCommandLineArguments(args).Returns(typedArgs);
            
            var result = parser.ParseCommandLineArguments(args);

            Assert.That(result.Raw["foo"], Is.EqualTo("bar"));
            Assert.That(result.Raw["bar"], Is.EqualTo("foo"));
        }
    }
}
