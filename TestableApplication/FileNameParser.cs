using System;

namespace TestableApplication
{
    public class FileNameParser : IFileNameParser
    {
        public DateTime Parse(string fileName)
        {
            return DateTime.Parse(fileName.Split('.')[0]);
        }
    }
}