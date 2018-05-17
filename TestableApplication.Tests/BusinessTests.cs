using System;
using System.Collections.Generic;
using Autofac;
using NSubstitute;
using Xunit;

namespace TestableApplication.Tests
{
    public class BusinessTests
    {
        private readonly IContainer _container;

        public BusinessTests()
        {
            _container = ContainerWithSubstitutesGenerator.GetContainerBuilder()
                .With<IBusiness, Business>()
                .Build();

            _container.Resolve<IFileReader>().GetFiles().Returns(new List<FileData>());
        }

        [Fact]
        public void ShouldReadExistingFiles()
        {
            _container.Resolve<IBusiness>().Run();

            _container.Resolve<IFileReader>().Received(1).GetFiles();
        }

        [Fact]
        public void ShouldGenerateFileNameFromCurrentDate()
        {
            _container.Resolve<IBusiness>().Run();

            _container.Resolve<IFileNameGenerator>().Received(1).Generate(Arg.Any<DateTime>());
        }

        [Fact]
        public void ShouldGetDataFromServiceWhenNoFile()
        {
            _container.Resolve<IBusiness>().Run();

            _container.Resolve<ICurrencyService>().Received(1).GetLatest();
        }

        [Fact]
        public void ShouldNotGetDataFromServiceWhenFileExists()
        {
            _container.Resolve<IFileReader>().GetFiles().Returns(new List<FileData> { new FileData { FileName = "2017-01-01.txt" } });
            _container.Resolve<IFileNameGenerator>().Generate(Arg.Any<DateTime>()).Returns("2017-01-01.txt");

            _container.Resolve<IBusiness>().Run();

            _container.Resolve<ICurrencyService>().Received(0).GetLatest();
        }

        [Fact]
        public void ShouldSaveDataFromService()
        {
            _container.Resolve<IBusiness>().Run();

            _container.Resolve<IFileWriter>().Received(1).Save(Arg.Any<string>(), Arg.Any<string>());
        }
    }
}
