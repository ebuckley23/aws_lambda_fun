using Common.Abstractions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Implementation
{
    public class StructuremapResolver : IResolver
    {
        private readonly IContainer _container;
        public StructuremapResolver()
        {
            _container = new Container();
            _container.Configure(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssembliesAndExecutablesFromApplicationBaseDirectory();
                    scanner.WithDefaultConventions();
                });
            });
        }

        public StructuremapResolver(Action<ConfigurationExpression> config)
        {
            _container = new Container();
            _container.Configure(config);
        }

        public StructuremapResolver(Action<ConfigurationExpression> config, Action<StructureMap.Graph.IAssemblyScanner> scan)
            : this(config)
        {
            _container.Configure(cfg => cfg.Scan(scan));
        }

        public TInstanceType Resolve<TInstanceType>()
        {
            return _container.GetInstance<TInstanceType>();
        }

        public IEnumerable<TInstanceType> GetAll<TInstanceType>()
        {
            return _container.GetAllInstances<TInstanceType>();
        }
    }
}
