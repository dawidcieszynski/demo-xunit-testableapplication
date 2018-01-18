using System.IO.Abstractions;

namespace TestableApplication
{
    public class FileWriter
    {
        private readonly IFileSystem _fileSystem;

        public FileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Save(string path, string contents)
        {
            _fileSystem.File.WriteAllText(path, contents);
        }
    }
}