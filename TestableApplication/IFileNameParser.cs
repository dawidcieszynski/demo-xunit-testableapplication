using System;

namespace TestableApplication
{
    public interface IFileNameParser
    {
        DateTime Parse(string fileName);
    }
}