namespace Singleton.Contracts
{
    public interface ISingletonContainer
    {
        static ISingletonContainer Instance { get; }

        int GetPopulation(string name);
    }
}
