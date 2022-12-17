using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CustomStack<T>
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
    }
}
