using System;

namespace Explicit
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ReadCitizens();
        }

        private static void ReadCitizens()
        {
            var line = Console.ReadLine();

            if (line == "End") return;

            var citizenData = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var citizenName = citizenData[0];
            var citizenCountry = citizenData[1];
            var citizenAge = int.Parse(citizenData[2]);

            var citizen = new Citizen(citizenName, citizenAge, citizenCountry);

            Console.WriteLine((citizen as IPerson).GetName());
            Console.WriteLine((citizen as IResident).GetName());

            ReadCitizens();
        }
    }
}
