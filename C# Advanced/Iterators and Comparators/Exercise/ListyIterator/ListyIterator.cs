using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        public List<T> List { get; set; }

        public ListyIterator(IEnumerable<T> list)
        {
            this.List = list.ToList();
            this.index = 0;
        }

        public bool Move()
        {
            if (!HasNext()) return false;
            this.index++;
            return true;
        }

        public bool HasNext()
        {
            if (index + 1 >= this.List.Count) return false;
            return true;
        }

        public void Print()
        {
            if (this.List == null || this.List.Count == 0) throw new InvalidOperationException("Invalid Operation!");
            Console.WriteLine(List[index]);
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.List));
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
