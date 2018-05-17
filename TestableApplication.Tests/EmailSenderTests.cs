using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using nDumbster.Smtp;
using Xunit;

namespace TestableApplication.Tests
{
    public class EmailSenderTests
    {
        [Theory]
        [AutoData]
        public void ShouldSendEmailWithContent(string email, string content, string subject)
        {
            using (var smtp = SimpleSmtpServer.Start())
            {
                var sender = new EmailSender();

                sender.Send($"{email}@example.com", content, subject);

                smtp.ReceivedEmail.First().Subject.Should().Be(subject);
                smtp.ReceivedEmail.First().Body.Should().Be(content);
                smtp.ReceivedEmail.First().To.First().Should().Be($"{email}@example.com");
            }
        }
    }
}