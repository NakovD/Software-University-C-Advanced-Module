using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Basketball
{
    public class StartUp
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            // Initialize the repository (Team)
            Team team = new Team("BHTC", 5, 'A');

            // Initialize entity
            Player firstPlayer = new Player("Viktor", "Center", 97.5, 10);
            Player s = new Player("Viktor", "Center", 97.5, 10);
            Player d = new Player("Viktor", "Center", 97.5, 10);
            Player g = new Player("Viktor", "some", 97.5, 10);

            Console.WriteLine(team.AddPlayer(firstPlayer));
            Console.WriteLine(team.AddPlayer(s));
            Console.WriteLine(team.AddPlayer(d));
            Console.WriteLine(team.AddPlayer(g));

            Console.WriteLine(team.RemovePlayerByPosition("Center"));

            Console.Write(team.OpenPositions);
        }
    }
}
