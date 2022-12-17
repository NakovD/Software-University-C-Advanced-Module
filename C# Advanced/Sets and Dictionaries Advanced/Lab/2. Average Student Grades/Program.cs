using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var studentsCount = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>(studentsCount);

            for (int i = 0; i < studentsCount; i++)
            {
                var currentStudent = Console.ReadLine().Split(" ");
                var studentName = currentStudent[0];
                var studentGrade = decimal.Parse(currentStudent[1]);
                if (students.ContainsKey(studentName))
                {
                    students[studentName].Add(studentGrade);
                    continue;
                }

                students.Add(studentName, new List<decimal> { studentGrade });
            }

            foreach (var student in students)
            {
                var averageGrade = student.Value.Average();
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {averageGrade:f2})");
            }
        }
    }
}
