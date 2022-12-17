using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private DoublyLinkedList<T> stack;

        public int Count { get; private set; }

        public CustomStack()
        {
            stack = new DoublyLinkedList<T>();
        }

        public void Push(T element)
        {
            stack.AddFirst(element);
            this.Count++;
        }

        public T Pop()
        {
            ValidateStack();
            this.Count--;
            return stack.RemoveFirst();
        }

        public T Peek()
        {
            ValidateStack();
            return this.stack.Head.Value;
        }

        public void ForEach(Action<T> action)
        {
            stack.ForEach(action);
        }

        private void ValidateStack()
        {
            if (this.Count == 0) throw new Exception("Stack is empty");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return stack.GetElement(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
