using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3) throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                firstName = value;
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3) throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                lastName = value;
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0) throw new ArgumentException("Age cannot be zero or a negative integer!");
                age = value;
            }
        }

        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (value < 460) throw new ArgumentException("Salary cannot be less than 650 leva!");
                salary = value;
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30) percentage = percentage / 2;
            percentage = percentage / 100;
            Salary = Salary * percentage + Salary;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
