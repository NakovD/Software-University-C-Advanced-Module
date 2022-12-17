using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public interface IEntity
    {
        bool isValid();
    }
    public class Person : IEntity
    {
        public string Name { get; set; }

        public bool isValid()
        {
            return true;
        }
    }

    public class Employee : Person
    {
        public int Id { get; set; }

        public virtual void DoWork()
        {
            Console.WriteLine("Doing real work");
        }
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            Console.WriteLine("Create a meeting");
        }
    }
}
