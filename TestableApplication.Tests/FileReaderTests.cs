using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace TestableApplication.Tests
{
    public class FileReaderTests
    {
        [Fact]
        public void ShouldReturnListOfExistingFilesWithContent()
        {
            var assemblyDirectory = GetAssemblyDirectory();
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                {assemblyDirectory + @"\2013-01-01.txt", new MockFileData("{\"rates\": {\"PLN\": 4.1713,}}")}
            });

            var fileReader = new FileReader(fileSystem);

            var files = fileReader.GetFiles();

            files.Count.Should().Be(1);
            files[0].FileName.Should().Be("2013-01-01.txt");
            files[0].Data.rates.PLN.Should().Be(4.1713);
        }

        private static string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directoryName = Path.GetDirectoryName(path);
            return directoryName;
        }
    }
}