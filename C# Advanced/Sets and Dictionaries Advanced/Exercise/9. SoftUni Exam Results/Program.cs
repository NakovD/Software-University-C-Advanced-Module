using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var students = new Dictionary<string, Student>();
            var languages = new Dictionary<string, int>();

            while (!input.Contains("exam finished"))
            {
                var currentInput = input.Split("-");
                input = Console.ReadLine();
                var studentName = currentInput[0];
                if (currentInput.Length == 2)
                {
                    if (students.ContainsKey(studentName)) students.Remove(studentName);
                    continue;
                }

                var language = currentInput[1];
                var points = int.Parse(currentInput[2]);
                if (!languages.ContainsKey(language)) languages.Add(language, 0);
                if (!students.ContainsKey(studentName)) students.Add(studentName, new Student(language));
                var currentStudentMaxPoints = students[studentName].MaxPoints;
                if (currentStudentMaxPoints <= points) students[studentName].MaxPoints = points;
                languages[language] += 1;
            }

            var orderedParticipants = students
                .OrderByDescending(student => student.Value.MaxPoints)
                .ThenBy(student => student.Key)
                .Select(student => $"{student.Key} | {student.Value.MaxPoints}").ToArray();

            var orderedLanguages = languages
                .OrderByDescending(language => language.Value)
                .ThenBy(language => language.Key)
                .Select(language => $"{language.Key} - {language.Value}");

            Console.WriteLine("Results:");
            Console.WriteLine(string.Join("\n", orderedParticipants));
            Console.WriteLine("Submissions:");
            Console.WriteLine(string.Join("\n", orderedLanguages));
        }
    }


    class Student
    {
        public string Name { get; set; }
        public int MaxPoints { get; set; }

        public Student(string name)
        {
            this.Name = name;
            this.MaxPoints = 0;
        }
    }
}
