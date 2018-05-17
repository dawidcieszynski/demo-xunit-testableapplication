using System;

namespace TestableApplication
{
    public interface IFileNameGenerator
    {
        string Generate(DateTime date);
    }
}