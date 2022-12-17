using System;

namespace Workshop___LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new DoublyLinkedList<int>();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);

            var someNode = linkedList.GetElement(1);

            linkedList.InserAfter(someNode, 22);

            Console.WriteLine(string.Join(" ", linkedList.ToArray()));

        }
    }
}
