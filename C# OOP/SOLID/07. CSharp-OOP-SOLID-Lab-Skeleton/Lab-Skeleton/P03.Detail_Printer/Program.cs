using P03.Detail_Printer.Contracts;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var employeeList = new List<IPrintable>() { new TechLead("Gosho"), new Employee("Tosho"), new Manager("Tereza", new string[] { "doc", "doc1", "doc2" }) };

            var detailsPrinter = new DetailsPrinter(employeeList);

            detailsPrinter.PrintDetails();
        }
    }
}
