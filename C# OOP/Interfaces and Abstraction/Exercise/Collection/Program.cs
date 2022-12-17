using System;
using System.Text;

namespace Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection<string>();
            var collection = new AddRemoveCollection<string>();
            var myList = new MyList<string>();

            var itemsToAdd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var addCollectionSb = new StringBuilder();
            var collectionSb = new StringBuilder();
            var myListSb = new StringBuilder();

            foreach (var _string in itemsToAdd)
            {
                addCollectionSb.Append(addCollection.Add(_string) + " ");
                collectionSb.Append(collection.Add(_string) + " ");
                myListSb.Append(myList.Add(_string) + " ");
            }

            Console.WriteLine(addCollectionSb.ToString().Trim());
            Console.WriteLine(collectionSb.ToString().Trim());
            Console.WriteLine(myListSb.ToString().Trim());

            collectionSb.Clear();
            myListSb.Clear();

            var timesToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < timesToRemove; i++)
            {
                collectionSb.Append(collection.Remove() + " ");
                myListSb.Append(myList.Remove() + " ");
            }

            Console.WriteLine(collectionSb.ToString().Trim());
            Console.WriteLine(myListSb.ToString().Trim());
        }
    }
}
