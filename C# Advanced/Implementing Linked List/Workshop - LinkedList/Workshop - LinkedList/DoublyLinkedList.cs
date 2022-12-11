using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop___LinkedList
{
    public class DoublyLinkedList<T>
    {
        public class ListNode
        {
            public ListNode NextNode { get; set; }

            public ListNode PreviousNode { get; set; }

            public T Value { get; }

            public ListNode(T value)
            {
                this.Value = value;
            }
            
        }

        private ListNode head;

        private ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(T entity)
        {
            this.Count++;

            if (this.Count == 1)
            {
                this.head = new ListNode(entity);

                this.tail = this.head;

                return;
            }

            var newHead = new ListNode(entity) { NextNode = this.head };
            this.head.PreviousNode = newHead;
            this.head = newHead;

        }

        public void AddLast(T entity)
        {
            this.Count++;

            if (this.Count == 1)
            {
                this.tail = new ListNode(entity);
                this.head = this.tail;
                return;
            }

            var newNode = new ListNode(entity) { PreviousNode = this.tail };
            this.tail.NextNode = newNode;
            this.tail = newNode;

        }

        public void InsertBefore(ListNode node, T value)
        {
            var newNode = new ListNode(value) {  NextNode = node };
            if (node.PreviousNode != null)
            {
                newNode.PreviousNode = node.PreviousNode;
                node.PreviousNode.NextNode = newNode;
            }
            else this.head = newNode;
            node.PreviousNode = newNode;
            this.Count++;
        }
        
        public void InserAfter(ListNode node, T value)
        {
            var newNode = new ListNode(value) { PreviousNode = node };
            if (node.NextNode != null)
            {
                newNode.NextNode = node.NextNode;
                node.NextNode.PreviousNode = newNode;
            }
            else this.tail = newNode;
            node.NextNode = newNode;
            this.Count++;
        }

        public T GetElement(int index)
        {
            var currentNode = this.head;
            T result = default(T);
            var counter = 0;

            while (currentNode != null)
            {
                if (counter == index) { result = currentNode.Value; break; }
                currentNode = currentNode.NextNode;
            }

            return result;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0) throw new Exception("Linked list is empty");

            this.Count--;

            var result = this.head.Value;

            if (this.Count == 0)
            {
                this.head = null;
                this.tail = null;
                return result;
            }

            var newHead = this.head.NextNode;
            this.head = newHead;
            this.head.PreviousNode = null;

            return result;
        } 

        public T RemoveLast()
        {
            if (this.Count == 0) throw new Exception("Linked list is empty");

            this.Count--;

            var result = this.head.Value;

            if (this.Count == 0)
            {
                this.head = null;
                this.tail = null;
                return result;
            }

            var newTail = this.tail.PreviousNode;
            this.tail = newTail;
            this.tail.NextNode = null;

            return result;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];

            var currentNode = this.head;

            var index = 0;

            while (currentNode != null) {
                resultArray[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return resultArray;
        }
    }
}
