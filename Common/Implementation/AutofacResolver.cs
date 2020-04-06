using Autofac;
using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Implementation
{
    public class AutofacResolver : IResolver
    {
        private IContainer _container;
        public AutofacResolver(Action<ContainerBuilder> builder)
        {
            var containerBuilder = new ContainerBuilder();
            builder(containerBuilder);
            _container = containerBuilder.Build();
        }

        public TInstanceType Resolve<TInstanceType>()
        {
            return _container.Resolve<TInstanceType>();
        }
    }
}
