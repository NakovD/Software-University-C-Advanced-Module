namespace Composite.Contracts
{
    using Models;

    internal interface IGiftOperations
    {
        void Add(GiftBase gift);

        void Remove(GiftBase gift);
    }
}
