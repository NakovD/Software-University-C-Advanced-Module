using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class StartUp
    {
        private static List<ICitizen> citizens = new List<ICitizen>();


        static void Main(string[] args)
        {
            ReadCommands();
            var lastDigitsFakeId = Console.ReadLine();

            var fakeCitizens = citizens
                .Where(citizen => citizen.Id.ToString().EndsWith(lastDigitsFakeId))
                .Select(citizen => $"{citizen.Id}");

            Console.WriteLine(String.Join(Environment.NewLine, fakeCitizens));
        }

        private static void ReadCommands()
        {
            var currentLine = Console.ReadLine();
            if (currentLine == "End") return;

            ParseCitizen(currentLine);

            ReadCommands();
        }

        private static void ParseCitizen(string citizenData)
        {
            var citizenDataArr = citizenData.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (citizenDataArr.Length == 3)
            {
                citizens.Add(new Person(citizenDataArr[0], int.Parse(citizenDataArr[1]), long.Parse(citizenDataArr[2])));
            }
            else
            {
                citizens.Add(new Robot(citizenDataArr[0], long.Parse(citizenDataArr[1])));
            }
        }
    }
}
