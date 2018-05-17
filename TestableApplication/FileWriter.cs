using System.IO;
using System.IO.Abstractions;

namespace TestableApplication
{
    public class FileWriter : IFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public FileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Save(string path, string contents)
        {
            using (var stream = _fileSystem.File.Open(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    streamWriter.Write(contents);
                    streamWriter.Flush();
                }
            }
        }
    }
}