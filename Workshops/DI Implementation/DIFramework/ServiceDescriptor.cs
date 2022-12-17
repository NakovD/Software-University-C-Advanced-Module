namespace DIFramework
{
    using DIFramework.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using IServiceProvider = Contracts.IServiceProvider;

    public class ServiceDescriptor : IServiceDescriptor
    {
        public Type ServiceType { get; private set; }

        public Type ImplementationType { get; private set; }

        public Func<IServiceProvider, object> ImplementationFactory { get; private set; }

        public bool HasImplementationFactory { get; }

        public ServiceDescriptor(Type serviceType, Type implementationType)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
        }

        public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            ServiceType = serviceType;
            ImplementationFactory = implementationFactory;
            HasImplementationFactory = true;
        }
    }
}
