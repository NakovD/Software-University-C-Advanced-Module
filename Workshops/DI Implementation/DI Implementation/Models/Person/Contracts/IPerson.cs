namespace DI_Implementation.Models.Person.Contracts
{
    using DI_Implementation.Contracts;

    public interface IPerson : INamed
    {
        int Age { get; }
    }
}
