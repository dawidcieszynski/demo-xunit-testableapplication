using System.IO.Abstractions;
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

            fileWriter.Save("", "");

            fileSystem.File.Received().WriteAllText(Arg.Any<string>(), Arg.Any<string>());
        }
    }
}