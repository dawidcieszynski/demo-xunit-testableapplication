using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace TestableApplication
{
    public class FileReader : IFileReader
    {
        private readonly IFileSystem _fileSystem;

        public FileReader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public List<FileData> GetFiles()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var files = _fileSystem.Directory.GetFiles(Path.GetDirectoryName(path), "*.txt");
            var data = files.Select(fileName =>
            {
                var content = _fileSystem.File.ReadAllText(fileName);
                return new FileData
                {
                    FileName = _fileSystem.Path.GetFileName(fileName),
                    Data = JsonConvert.DeserializeObject<CurrencyData>(content)
                };
            });

            return data.ToList();
        }
    }
}