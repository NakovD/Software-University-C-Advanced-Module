namespace DIFramework
{
    using DIFramework.Contracts;

    public class ServiceCollection : IServiceCollection
    {
        private List<IServiceDescriptor> serviceDescriptors;

        public ServiceCollection()
        {
            serviceDescriptors = new List<IServiceDescriptor>();
        }

        public IServiceCollection AddTransient(Type service, Type implementation)
        {
            ThrowIfServiceAlreadyExists(service);

            var serviceDescriptor = new ServiceDescriptor(service, implementation);

            serviceDescriptors.Add(serviceDescriptor);

            return this;
        }

        public IServiceCollection AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        => AddTransient(typeof(TService), typeof(TImplementation));

        public IServiceCollection AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> factory)
            where TService : class
            where TImplementation : class, TService
        {
            var serviceType = typeof(TService);

            var serviceDescriptor = new ServiceDescriptor(serviceType, factory);

            ThrowIfServiceAlreadyExists(serviceType);

            serviceDescriptors.Add(serviceDescriptor);

            return this;
        }

        public ServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(serviceDescriptors);
        }

        private void ThrowIfServiceAlreadyExists(Type serviceType)
        {
            var doesServiceAlreadyExist = ValidateIfServiceAlreadyExists(serviceType);

            if (doesServiceAlreadyExist) throw new ArgumentException($"Service of type: {serviceType.Name} already has an implementation!");
        }

        private bool ValidateIfServiceAlreadyExists(Type serviceType) => serviceDescriptors.Any(sd => sd.ServiceType.Name == serviceType.Name);
    }
}