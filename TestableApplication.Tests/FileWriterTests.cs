using System.IO.Abstractions.TestingHelpers;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileWriterTests
    {
        [Theory]
        [AutoData]
        public void ShouldSaveContentToFile(string fileName, string content)
        {
            var fileSystem = new MockFileSystem();
            var fileWriter = new FileWriter(fileSystem);

            fileWriter.Save(fileName, content);

            fileSystem.File.ReadAllText(fileName).Should().Be(content);
        }
    }
}