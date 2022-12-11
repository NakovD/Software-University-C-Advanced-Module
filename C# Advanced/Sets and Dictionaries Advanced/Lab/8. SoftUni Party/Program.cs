using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var guestList = new HashSet<string>();
            var vipGuestsFirstLetter = "1234567890";

            while (!input.Contains("PARTY"))
            {
                var guest = input;
                guestList.Add(guest);
                input = Console.ReadLine();
            }
            
            while (!input.Contains("END"))
            {
                input = Console.ReadLine();
                var guestThatCame = input;
                if (guestList.Contains(guestThatCame)) guestList.Remove(guestThatCame);
            }

            var vipGuestsFirst = guestList.OrderByDescending(guest => vipGuestsFirstLetter.Contains(guest[0]));
            Console.WriteLine(guestList.Count);
            Console.WriteLine(string.Join("\n", vipGuestsFirst));
        }
    }
}
