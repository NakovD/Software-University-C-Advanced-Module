namespace DIFramework.Contracts
{
    public interface IServiceProvider
    {
        T GetRequiredService<T>();

        object GetService(Type serviceType);
    }
}
