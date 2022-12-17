using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ShoppingSpree
{
    public class Program
    {
        private static List<Person> people = new List<Person>();

        private static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            var peopleUnparsed = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            var productsUnparsed = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var personUnparsed in peopleUnparsed)
                {
                    var personData = personUnparsed.Split("=");
                    var personName = personData[0];
                    var money = int.Parse(personData[1]);
                    var person = new Person(personName, money);
                    people.Add(person);
                }

                foreach (var productUnparsed in productsUnparsed)
                {
                    var productData = productUnparsed.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    var productName = productData[0];
                    var productCost = int.Parse(productData[1]);
                    var product = new Product(productName, productCost);
                    products.Add(product);
                }

                ReadCommands();

                PrintFinalState();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void PrintFinalState()
        {
            Func<Person, string> personProductPrinter = person => person.Products.Count == 0 ? "Nothing bought" : string.Join(", ", person.Products.Select(product => product.Name));
            people.ForEach(person => Console.WriteLine($"{person.Name} - {personProductPrinter(person)}"));
        }

        private static void ReadCommands()
        {
            var currentCommand = Console.ReadLine();
            if (currentCommand == "END") return;

            var data = currentCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var personName = data[0];
            var productName = data[1];

            BuyProduct(personName, productName);

            ReadCommands();
        }

        private static void BuyProduct(string personName, string productName)
        {
            var neededPerson = people.SingleOrDefault(person => person.Name == personName);
            var neededProduct = products.SingleOrDefault(product => product.Name == productName);

            var isPurchaseSuccessful = neededPerson.BuyProduct(neededProduct);

            if (!isPurchaseSuccessful) Console.WriteLine($"{neededPerson.Name} can't afford {neededProduct.Name}");
            else Console.WriteLine($"{neededPerson.Name} bought {neededProduct.Name}");
        }
    }
}
