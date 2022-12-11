using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee, IPrintable
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Name = name;
            this.Documents = new List<string>(documents);
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<string> Documents { get; set; }

        public string Print()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Name);
            sb.AppendLine(string.Join(Environment.NewLine, Documents));

            return sb.ToString().Trim();
        }
    }
}
