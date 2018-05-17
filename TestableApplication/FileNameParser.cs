using System;

namespace TestableApplication
{
    public class FileNameParser
    {
        public DateTime Parse(string fileName)
        {
            return DateTime.Parse(fileName.Split('.')[0]);
        }
    }
}