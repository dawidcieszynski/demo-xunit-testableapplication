using Autofac;

namespace TestableApplication
{
    public class ContainerGenerator
    {
        public static ContainerBuilder GetContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterAssemblyTypes(typeof(ContainerGenerator).Assembly).AsImplementedInterfaces();

            return containerBuilder;
        }
    }
}