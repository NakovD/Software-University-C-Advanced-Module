namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    using static System.Net.Mime.MediaTypeNames;

    [TestFixture]
    public class Tests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            book = new Book("Percy", "Ceca");
        }

        [Test]
        [TestCase(null, "Ceca")]
        [TestCase("", "Ceca")]
        [TestCase("Percy", null)]
        [TestCase("Percy", "")]
        public void BookCtorThrowsWithInvalidArgs(string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() => book = new Book(bookName, author));
        }

        [Test]
        [TestCase("Percy", "Ceca")]
        public void BookCtorCreatesBookWithValidArgs(string bookName, string author)
        {
            var expectedBookName = bookName;
            var expectedAuthor = author;
            var expectedFootNoteCount = 0;

            book = new Book(bookName, author);

            var actualBookName = book.BookName;
            var actualAuthor = book.Author;
            var actualFootNoteCount = book.FootnoteCount;

            Assert.IsTrue(expectedBookName == actualBookName);
            Assert.IsTrue(expectedAuthor == actualAuthor);
            Assert.IsTrue(expectedFootNoteCount == actualFootNoteCount);
        }

        [Test]
        public void BookCtorCreatesFootNoteDictionary()
        {
            var expectedCount = 0;

            var actualCount = book.FootnoteCount;

            Assert.IsTrue(expectedCount == actualCount);
        }

        [Test]
        public void AddFootNoteThrowsWithInvalidFootnoteNumber()
        {
            book.AddFootnote(1, "text");

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "text"));
        }

        [Test]
        public void AddFootNoteAddsNewFootNote()
        {
            var footnoteNumber = 1;
            book.AddFootnote(footnoteNumber, "some text");
            var expectedCount = 1;
            var expectedFootNote = $"Footnote #{footnoteNumber}: {"some text"}";

            var actualCount = book.FootnoteCount;
            var actualFootNote = book.FindFootnote(footnoteNumber);

            Assert.IsTrue(expectedCount == actualCount);
            Assert.IsTrue(expectedFootNote == actualFootNote);
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void FindFootnoteThrowsWithInvalidFootnoteNumber(int footNoteNumber)
        {
            book.AddFootnote(1515, "50123");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(footNoteNumber));
        }

        [Test]
        [TestCase(1, "very fin text")]
        [TestCase(5, "more text")]
        [TestCase(100, "more sus")]
        public void FindFootnoteReturnsCorrectFootnote(int footNoteNumber, string text)
        {
            book.AddFootnote(footNoteNumber, text);

            var expectedResult = $"Footnote #{footNoteNumber}: {text}";

            var actualResult = book.FindFootnote(footNoteNumber);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [Test]
        public void AlterFootnoteThrowsWithInvalidFootnote()
        {
            book.AddFootnote(1, "text");
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(5));
        }

        [Test]
        [TestCase("gosho")]
        [TestCase("Singing is awesome")]
        [TestCase("Oh no, oh no, oh no, no, no")]
        public void AlterFootnoteUpdateTheFootNoteText(string newText)
        {
            var footNoteNumber = 5;
            book.AddFootnote(footNoteNumber, "wrapping up");

            var expectedResult = $"Footnote #{footNoteNumber}: {newText}"; ;

            book.AlterFootnote(footNoteNumber, newText);

            var actualResult = book.FindFootnote(5);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}