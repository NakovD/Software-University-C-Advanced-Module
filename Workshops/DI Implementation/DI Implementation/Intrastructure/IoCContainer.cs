namespace DI_Implementation.Intrastructure
{
    using DI_Implementation.Loggers;
    using DI_Implementation.Loggers.Contracts;
    using DI_Implementation.Models.Person.Contracts;
    using DI_Implementation.Repositories;
    using DI_Implementation.Repositories.Contracts;
    //using Microsoft.Extensions.DependencyInjection;

    using DIFramework;

    public class IoCContainer
    {
        public ServiceProvider Configure()
        {
            var serviceCollection = new ServiceCollection();

            //serviceCollection.AddTransient<ILogger, FileLogger>((serviceProvider) =>
            //{
            //    return new FileLogger("../../../customLogFile.txt");
            //});

            //serviceCollection.AddTransient<ILogger, FileLogger>();

            serviceCollection.AddTransient(typeof(ILogger), typeof(FileLogger));

            serviceCollection.AddTransient<IRepository<IPerson>, PersonRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
