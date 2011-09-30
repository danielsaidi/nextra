using NExtra.IO;
using NUnit.Framework;

namespace NExtra.Tests.IO
{
    public class FileSizePresenterBehavior
    {
        [Test]
        public void PresentFileSize_ShouldHandleBytes()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999), Is.EqualTo("999 B"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleKiloBytesWithoutDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999000), Is.EqualTo("999,00 kB"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleKiloBytesWithDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999110), Is.EqualTo("999,11 kB"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleMegaBytesWithoutDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999000000), Is.EqualTo("999,00 MB"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleMegaBytesWithDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999110000), Is.EqualTo("999,11 MB"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleGigaBytesWithoutDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999000000000), Is.EqualTo("999,00 GB"));
        }

        [Test]
        public void PresentFileSize_ShouldHandleGigaBytesWithDecimal()
        {
            Assert.That(new FileSizePresenter().PresentFileSize(999110000000), Is.EqualTo("999,11 GB"));
        }
    }
}
