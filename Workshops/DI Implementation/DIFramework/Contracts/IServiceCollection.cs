namespace DIFramework.Contracts
{
    public interface IServiceCollection
    {
        IServiceCollection AddTransient<TService, TImplementation>() 
            where TService : class
            where TImplementation : class, TService;

        IServiceCollection AddTransient(Type service, Type implementation);

        IServiceCollection AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> factory) 
            where TService : class
            where TImplementation : class, TService;

        ServiceProvider BuildServiceProvider();
    }
}