using System.IO;
using System.Reflection;
using System.Text;
using NExtra.Extensions;
using NExtra.IO;
using NUnit.Framework;

namespace NExtra.Tests.IO
{
    [TestFixture]
    public class StreamReaderFileEncodingResolverBehavior
    {
        private IFileEncodingResolver _resolver;


        [SetUp]
        public void Setup()
        {
            _resolver = new StreamReaderFileEncodingResolver();
        }


        [Test]
        public void ResolveFileEncoding_ShouldFailAndReturnDefaultEncodingEvenForResolvableFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var folderPath = assembly.GetFolderPath();
            var filePath = Path.Combine(folderPath, "Resources", "EncodingTest.txt");
            var encoding = _resolver.ResolveFileEncoding(filePath);

            Assert.That(encoding, Is.EqualTo(Encoding.UTF8));
        }

        [Test]
        public void ResolveFileEncoding_ShouldReturnDefaultEncodingForNonResolvableFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var folderPath = assembly.GetFolderPath();
            var filePath = Path.Combine(folderPath, "Resources", "EncodingTest.xml");
            var encoding = _resolver.ResolveFileEncoding(filePath);

            Assert.That(encoding, Is.EqualTo(Encoding.UTF8));
        }
    }
}
