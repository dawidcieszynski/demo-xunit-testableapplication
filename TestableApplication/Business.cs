using System;
using System.Configuration;
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
        private IEmailSender _emailSender;

        public Business(IFileReader fileReader, IFileNameGenerator fileNameGenerator, ICurrencyService currencyService, IFileWriter fileWriter, IEmailSender emailSender)
        {
            _fileReader = fileReader;
            _fileNameGenerator = fileNameGenerator;
            _currencyService = currencyService;
            _fileWriter = fileWriter;
            _emailSender = emailSender;
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

            var sendMailsTo = ConfigurationManager.AppSettings["SendMailsTo"];
            _emailSender.Send(sendMailsTo, JsonConvert.SerializeObject(files), "Currency Data");
        }
    }
}