namespace DIFramework.Contracts
{
    using System;

    public interface IServiceDescriptor
    {
        bool HasImplementationFactory { get; }

        Type ServiceType { get; }

        Type ImplementationType { get; }

        Func<IServiceProvider, object> ImplementationFactory { get; }
    }
}
