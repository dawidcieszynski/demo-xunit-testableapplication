using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileNameGeneratorTests
    {
        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] { new DateTime(2019, 10, 10), "2019-10-10.txt" };
            yield return new object[] { new DateTime(2017, 01, 10), "2017-01-10.txt" };
        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void ShouldGenerateFileNameWithGivenDate(DateTime date, string fileName)
        {
            var fileNameGenerator = new FileNameGenerator();

            var newFileName = fileNameGenerator.Generate(date);

            newFileName.Should().Be(fileName);
        }

        [Fact]
        public void ShouldGenerateNonEmptyFileName()
        {
            var fileNameGenerator = new FileNameGenerator();

            var newFileName = fileNameGenerator.Generate(DateTime.Now); // why Now?

            newFileName.Should().NotBeEmpty();
        }
    }
}