using FluentAssertions;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileNameParserTests
    {
        [Theory]
        [InlineData("2017-01-01.txt", 2017, 1, 1)]
        [InlineData("2019-10-01.txt", 2019, 10, 1)]
        public void ShouldReadDateFromFileName(string fileName, int y, int m, int d)
        {
            var parser = new FileNameParser();

            var date = parser.Parse(fileName);

            date.Year.Should().Be(y);
            date.Month.Should().Be(m);
            date.Day.Should().Be(d);
        }
    }
}