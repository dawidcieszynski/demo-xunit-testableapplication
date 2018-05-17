namespace TestableApplication
{
    public interface IEmailSender
    {
        void Send(string email, string content, string subject);
    }
}