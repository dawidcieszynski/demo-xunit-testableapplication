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
        }

        [Fact]
        public void ShouldReadExistingFiles()
        {
            _container.Resolve<IBusiness>().Run();

            _container.Resolve<IFileReader>().Received(1).GetFiles();
        }
    }
}