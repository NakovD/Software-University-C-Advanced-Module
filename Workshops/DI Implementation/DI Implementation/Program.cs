namespace DI_Implementation
{
    using Repositories;
    using Models.Person;
    using Loggers.Contracts;
    using DI_Implementation.Intrastructure;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person("David", 24);
            var anotherPerson = new Person("Hristo", 15);
            var serviceProvider = new IoCContainer().Configure();

            var logger = serviceProvider.GetRequiredService<ILogger>();
            var repository = new PersonRepository(logger);

            repository.Add(person);             //should show info message
            repository.Find(person.Name);       //should show info message
            repository.Remove(anotherPerson);   //should show error message
            repository.Find(anotherPerson.Name);//should show error message
        }
    }
}
