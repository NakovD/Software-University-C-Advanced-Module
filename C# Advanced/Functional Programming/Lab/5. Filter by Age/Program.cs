using System;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberLines = int.Parse(Console.ReadLine());
            var people = new Person[numberLines];

            for (int i = 0; i < numberLines; i++)
            {
                var personData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var newPerson = new Person(personData[0], int.Parse(personData[1]));
                people[i] = newPerson;
            }

            var condition = Console.ReadLine();
            var ageTreshold = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<Person, string, int, bool> peopleValidator = (person, cond, ageT) => cond == "younger" ? person.Age < ageT : person.Age >= ageT;
            Func<string[], string> peopleFormatter = _format => {
                if (_format.Length < 2) return _format[0] == "name" ? "{0}" : "{1}";
                if (_format[0] == "name") return "{0} - {1}";
                return "{1} - {0}";
            };

            var validPeople = people.Where(p => peopleValidator(p, condition, ageTreshold)).Select(p => string.Format(peopleFormatter(format), p.Name, p.Age));

            Console.WriteLine(string.Join(Environment.NewLine, validPeople));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
