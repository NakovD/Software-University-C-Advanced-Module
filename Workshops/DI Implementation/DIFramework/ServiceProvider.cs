namespace DIFramework
{
    using DIFramework.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using IServiceProvider = Contracts.IServiceProvider;

    public class ServiceProvider : IServiceProvider
    {
        private ICollection<IServiceDescriptor> serviceDescriptors;

        public ServiceProvider(List<IServiceDescriptor> serviceDescriptors)
        {
            this.serviceDescriptors = serviceDescriptors;
        }

        public T GetRequiredService<T>()
        {
            var requiredService = typeof(T);

            return (T)GetService(requiredService);
        }

        public object GetService(Type serviceType)
        {
            var serviceDescriptor = serviceDescriptors.Single(t => t.ServiceType.Name == serviceType.Name);

            if (serviceDescriptor.HasImplementationFactory)
            {
                return serviceDescriptor.ImplementationFactory(this);
            }

            var neededImplementation = serviceDescriptor.ImplementationType;

            object instance = null;

            var ctors = neededImplementation.GetConstructors();

            foreach (var ctor in ctors)
            {
                if (ctor.IsPrivate) continue;

                var parametersInfo = ctor.GetParameters();

                if (!parametersInfo.Any())
                {
                    instance = Activator.CreateInstance(neededImplementation);
                    break;
                }

                object[] parameters;

                try
                {
                    parameters = GetCtorParameters(parametersInfo);

                }
                catch (ArgumentException ex)
                {
                    continue;
                }

                Activator.CreateInstance(neededImplementation, parameters);
            }

            if (instance == null) throw new InvalidOperationException($"Implementation type {neededImplementation.Name} has no valid constructor. Please provide implementation factory!");

            return instance;
        }

        private object[] GetCtorParameters(ParameterInfo[] parametersInfo)
        {
            var parameters = new object[parametersInfo.Length];
            var index = 0;

            foreach (var parameterInfo in parametersInfo)
            {
                var isParamAbstract = parameterInfo.ParameterType;
                if (isParamAbstract.IsAbstract)
                {
                    parameters[index] = GetService(parameterInfo.ParameterType);
                    index++;
                    continue;
                }
                throw new ArgumentException();
            }

            return parameters;
        }
    }
}
