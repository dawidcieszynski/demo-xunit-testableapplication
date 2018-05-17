using System.IO.Abstractions;
using AutoFixture.Xunit2;
using NSubstitute;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileWriterTests
    {
        [Theory]
        [AutoData]
        public void ShouldSaveContentToFile(string fileName, string content)
        {
            var fileSystem = Substitute.For<IFileSystem>();
            var fileWriter = new FileWriter(fileSystem);

            fileWriter.Save(fileName, content);

            fileSystem.File.Received().WriteAllText(fileName, content);
        }
    }
}