using System;
using System.Linq;
using Autofac;
using NSubstitute;

namespace TestableApplication.Tests
{
    public static class ContainerWithSubstitutesGenerator
    {
        public static ContainerBuilder GetContainerBuilder()
        {
            var containerBuilder = new ContainerBuilder();
            var interfaces = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.FullName != null && type.FullName.StartsWith("TestableApplication."))
                .Where(type => type.IsInterface);

            foreach (var type in interfaces)
                containerBuilder.Register(context => Substitute.For(new[] { type }, new object[0]))
                    .As(type)
                    .InstancePerLifetimeScope();

            return containerBuilder;
        }

        public static ContainerBuilder With<TInterface, TImplementation>(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<TImplementation>().As<TInterface>();
            return containerBuilder;
        }
    }
}