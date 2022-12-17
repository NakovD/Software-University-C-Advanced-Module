using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IPrintable> printables;

        public DetailsPrinter(IList<IPrintable> printables)
        {
            this.printables = printables;
        }

        public void PrintDetails()
        {
            foreach (IPrintable pritable in printables)
            {
                Console.WriteLine(pritable.Print());
            }
        }
    }
}
