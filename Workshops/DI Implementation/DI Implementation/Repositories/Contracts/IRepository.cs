namespace DI_Implementation.Repositories.Contracts
{
    using DI_Implementation.Contracts;
    using System.Collections.Generic;

    public interface IRepository<T> where T : class, INamed
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T? Find(string name);
    }
}
