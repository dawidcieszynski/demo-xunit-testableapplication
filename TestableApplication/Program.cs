using System;
using Autofac;

namespace TestableApplication
{
    public static class Program
    {
        public static void Main()
        {
            var container = ContainerGenerator.GetContainerBuilder().Build();
            var business = container.Resolve<IBusiness>();
            business.Run();

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}