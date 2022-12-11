using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CustomQueue<T>
    {
        private DoublyLinkedList<T> queue;

        public int Count { get; private set; }

        public CustomQueue()
        {
            this.queue = new DoublyLinkedList<T>();
        }

        public void Enqueue(T element)
        {
            queue.AddLast(element);
            this.Count++;
        }

        public T Dequeue()
        {
            ValidateQueue();
            this.Count--;
            return queue.RemoveFirst();
        }

        public T Peek()
        {
            ValidateQueue();
            return queue.Tail.Value;
        }

        public void Clear()
        {
            this.Count = 0;
            this.queue = new DoublyLinkedList<T>();
        }

        public void ForEach(Action<T> action)
        {
            this.queue.ForEach(action);
        }

        private void ValidateQueue()
        {
            if (this.Count == 0) throw new Exception("Queue is empty");
        }

    }
}
