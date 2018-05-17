using System;

namespace TestableApplication
{
    public class Business : IBusiness
    {
        private readonly IFileReader _fileReader;
        private readonly IFileNameGenerator _fileNameGenerator;

        public Business(IFileReader fileReader, IFileNameGenerator fileNameGenerator)
        {
            _fileReader = fileReader;
            _fileNameGenerator = fileNameGenerator;
        }

        public void Run()
        {
            _fileReader.GetFiles();
            _fileNameGenerator.Generate(DateTime.Now);
        }
    }
}