using System;
using System.Linq;
using System.Text;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineInput = Console.ReadLine();
            
            Func<string, bool> startsWithCapital = word => char.IsUpper(word[0]);
            
            var upperCaseLetters = lineInput
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(startsWithCapital);

            Console.WriteLine(string.Join(Environment.NewLine, upperCaseLetters));
        }
    }
}
