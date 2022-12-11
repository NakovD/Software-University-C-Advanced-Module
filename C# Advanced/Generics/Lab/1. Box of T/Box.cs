using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> box;

        public int Count { get => this.box.Count; }

        public Box()
        {
            this.box = new List<T>();
        }

        public void Add(T element) => this.box.Add(element);

        public T Remove()
        {
            var elementToReturn = box.Last();
            box.RemoveAt(box.Count - 1);
            return elementToReturn;
        }
    }
}
