namespace TestableApplication
{
    public class Business : IBusiness
    {
        private readonly IFileReader _fileReader;

        public Business(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public void Run()
        {
            _fileReader.GetFiles();
        }
    }
}