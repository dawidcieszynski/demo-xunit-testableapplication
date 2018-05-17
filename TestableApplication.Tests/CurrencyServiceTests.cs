using FluentAssertions;
using Xunit;

namespace TestableApplication.Tests
{
    public class CurrencyServiceTests
    {
        [Fact]
        public void ShouldReturnCurrencyData()
        {
            var service = new CurrencyService();

            var data = service.GetLatest();

            data.rates.PLN.Should().BeGreaterThan(0);
        }
    }
}