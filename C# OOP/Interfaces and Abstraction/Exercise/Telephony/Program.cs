using System;
using System.Linq;

namespace Telephony
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IStationaryPhone phone = new Phone();
            ISmartphone smartphone = new Smartphone();

            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var number in numbers)
            {
                var isInvalid = int.TryParse(number, out int validNumber);
                if (!isInvalid)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                var output = string.Empty;
                if (number.Length == 10) output = smartphone.Call(number);
                else if (number.Length == 7) output = phone.Call(number);

                Console.WriteLine(output);
            }

            foreach (var website in websites)
            {
                var isValid = !website.Any(char.IsDigit);
                if (!isValid)
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine(smartphone.BrowseWeb(website));
            }
        }
    }
}
