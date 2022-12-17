using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Contracts
{
    public class TechLead : IEmployee, IPrintable
    {
        public string Name { get; private set; }

        public TechLead(string name)
        {
            Name = name;
        }

        public string Print()
        {
            return $"Tech lead name: {Name}. This guy has a lot of experience.";
        }
    }
}
