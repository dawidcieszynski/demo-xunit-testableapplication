using System.IO.Abstractions;
using AutoFixture;
using NSubstitute;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileWriterTests
    {
        [Fact]
        public void ShouldSaveContentToFile()
        {
            var fileSystem = Substitute.For<IFileSystem>();
            var fileWriter = new FileWriter(fileSystem);
            var fixture = new Fixture();
            var fileName = fixture.Create<string>();
            var content = fixture.Create<string>();

            fileWriter.Save(fileName, content);

            fileSystem.File.Received().WriteAllText(fileName, content);
        }
    }
}