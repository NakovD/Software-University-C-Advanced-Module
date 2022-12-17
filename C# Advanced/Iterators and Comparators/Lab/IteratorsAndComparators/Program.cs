using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);


            foreach (Book book in libraryTwo)
            {
                Console.WriteLine(book);
            }

        }
    }


    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public IReadOnlyList<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }

        public int CompareTo(Book other)
        {
            var result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                result = this.Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            var comparingByTitle = x.Title.CompareTo(y.Title);
            if (comparingByTitle == 0) return y.Year.CompareTo(x.Year);
            return comparingByTitle;
        }
    }

    public class Library : IEnumerable<Book>
    {
        private List<Book> books { get; set; }

        private class LibraryIterator : IEnumerator<Book>
        {

            private readonly List<Book> books;

            private int currentIndex;

            public Book Current => books[currentIndex];

            object IEnumerator.Current => this.Current;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++this.currentIndex < this.books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
            this.books.Sort(new BookComparator());
        }
    }

}
