using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WorkshopListStackQueue
{
    internal class CustomList<T>
    {
        private T[] internalArray;


        private enum ListActions
        {
            Removing = 0,
            Adding = 1,
        }

        public int Count { get; private set; }

        public CustomList()
        {
            this.internalArray = new T[4];
        }

        public CustomList(int capacity)
        {
            this.internalArray = new T[capacity];
        }

        public T this[int i]
        {

            get
            {
                ValidateIndex(i);

                return this.internalArray[i];
            }
            set
            {
                ValidateIndex(i);

                this.internalArray[i] = value;
            }
        }

        #region Public Methods

        public void Add(T element)
        {
            if (this.Count == internalArray.Length)
            {
                ResizeList();
            }

            this.internalArray[this.Count] = element;

            this.Count++;
        }

        public T RemoveAt(int index)
        {
            ValidateIndex(index);
            var elementToReturn = this.internalArray[index];

            RearrangeList(index, ListActions.Removing);

            this.Count--;

            return elementToReturn;
        }

        public bool Contains(T element)
        {
            var isElementInList = false;

            var index = 0;

            while (index < this.Count)
            {
                var currentElement = this.internalArray[index];
                if (currentElement.Equals(element)) { isElementInList = true; break; }
                index++;
            }

            return isElementInList;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);
            if (firstIndex == secondIndex) throw new ArgumentException("Provided indexes are equal");

            var firstValue = this.internalArray[firstIndex];
            var secondValue = this.internalArray[secondIndex];
            this.internalArray[firstIndex] = secondValue;
            this.internalArray[secondIndex] = firstValue;
        }

        public void Insert(int index, T element)
        {
            ValidateIndex(index);

            RearrangeList(index, ListActions.Removing);

            this.internalArray[index] = element;

            this.Count++;
        }

        public void Reverse()
        {
            var newArray = new T[this.internalArray.Length];
            var newArrayIndex = 0;

            for (int i = this.Count - 1; i >= 0; i--)
            {
                newArray[newArrayIndex] = this.internalArray[i];
                newArrayIndex++;
            }

            this.internalArray = newArray;
        }

        #endregion

        #region Private Methods

        private void ValidateIndex(int index)
        {
            if (index >= this.Count) throw new IndexOutOfRangeException("Index was outside of the bounds of the list");
        }

        private void ResizeList()
        {
            var newArray = new T[this.Count * 2];

            for (int i = 0; i < internalArray.Length; i++)
            {
                newArray[i] = internalArray[i];
            }

            this.internalArray = newArray;

        }

        private void RearrangeList(int index, ListActions action)
        {
            var newArray = new T[this.internalArray.Length]; 

            Array.Copy(this.internalArray, newArray, this.internalArray.Length);

            for (int i = index; i < this.Count; i++)
            {
                if (action == ListActions.Removing) newArray[i + 1] = this.internalArray[i];
                else newArray[i] = this.internalArray[i + 1];
            }

            this.internalArray = newArray;
        }

        #endregion
    }
}
