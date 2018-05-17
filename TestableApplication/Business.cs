using System;
using System.Linq;
using Newtonsoft.Json;

namespace TestableApplication
{
    public class Business : IBusiness
    {
        private readonly IFileReader _fileReader;
        private readonly IFileNameGenerator _fileNameGenerator;
        private readonly ICurrencyService _currencyService;
        private readonly IFileWriter _fileWriter;

        public Business(IFileReader fileReader, IFileNameGenerator fileNameGenerator, ICurrencyService currencyService, IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileNameGenerator = fileNameGenerator;
            _currencyService = currencyService;
            _fileWriter = fileWriter;
        }

        public void Run()
        {
            var files = _fileReader.GetFiles();
            var fileName = _fileNameGenerator.Generate(DateTime.Now);
            if (files.All(file => file.FileName != fileName))
            {
                var result = _currencyService.GetLatest();
                files.Add(new FileData
                {
                    FileName = fileName,
                    Data = result
                });
                _fileWriter.Save(fileName, JsonConvert.SerializeObject(result));
            }
        }
    }
}