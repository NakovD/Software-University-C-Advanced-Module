using System;
using System.Collections.Generic;
using System.Text;
using Military.Contracts;

namespace Military
{
    public class Private : Soldier,IPrivate
    {
        public decimal Salary { get; private set; }

        public Private(string firstName, string lastName, string id, decimal salary) : base(firstName, lastName, id)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }
    }
}
