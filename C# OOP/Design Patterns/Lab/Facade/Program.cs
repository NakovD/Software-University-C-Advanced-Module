namespace Facade
{
    using System;

    using Facade.Models;

    public class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                                        .Info
                                            .WithType("Folkswagen")
                                            .WithNumberOfDoors(4)
                                         .Built
                                             .InCity("Sliven")
                                             .AtAddress("Slivenski hotel Jorgo")
                                         .Build();

            Console.WriteLine(car);
        }
    }
}
