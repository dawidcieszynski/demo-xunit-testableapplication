using System.Collections.Generic;

namespace TestableApplication
{
    public interface IFileReader
    {
        List<FileData> GetFiles();
    }
}