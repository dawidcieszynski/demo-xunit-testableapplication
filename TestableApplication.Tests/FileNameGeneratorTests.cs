using Xunit;

namespace TestableApplication.Tests
{
    public class FileNameGeneratorTests
    {
        [Fact]
        public void ShouldGenerateNonEmptyFileName()
        {
            var fileNameGenerator = new FileNameGenerator();

            var newFileName = fileNameGenerator.Generate();

            Assert.NotEmpty(newFileName);
        }
    }
}