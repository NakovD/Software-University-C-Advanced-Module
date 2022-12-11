namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        private int databaseCapacity = 16;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [Test]
        public void Test_DatabaseCtor()
        {
            var data = new int[3] { 1, 2, 3 };

            database = new Database(data);

            var databaseState = database.Fetch();

            Assert.AreEqual(data, databaseState, "Constructor doesn't fill the database correctly.");
        }

        [Test]
        public void Test_DatabaseCtorCount()
        {
            var data = new int[] { 1, 2, 3 };
            database = new Database(data);

            Assert.IsTrue(database.Count == data.Length);
        }

        [Test]
        public void Test_DatabaseCtorThrowsWhenCapacityOverflows()
        {
            var data = new int[17] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(data);
            }, $"Database doesn't throw when overflowing the given capacity - {databaseCapacity}.");
        }

        [Test]
        public void Test_AddMethodAddsElementAtLastFreeIndex()
        {
            database.Add(1);

            var dbState = database.Fetch();

            Assert.IsTrue(dbState[dbState.Length - 1] == 1, "Database doesn't add in the last free index.");
        }

        [Test]
        public void Test_AddMethodThrowsWhenOveflowingDBCapacity()
        {
            database = new Database(new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(17);
            }, $"Database doesn't throw when overflowing given capacity - {databaseCapacity}.");

        }

        [Test]
        public void Test_RemoveMethodRemovesAtTheLastIndex()
        {
            database = new Database(1, 2, 3, 4);

            database.Remove();

            var dbState = database.Fetch();

            Assert.IsTrue(dbState[dbState.Length - 1] == 3, "Remove method doesn't remove from database at the last index.");
        }

        [Test]
        public void Test_RemoveMethodThrowsIfDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Empty database doesn't throw when removing elements.");
        }

        [Test]
        public void TestFetchMethodReturnsTheDBAsArray()
        {
            database = new Database(1, 2, 3);

            var fetchedArray = database.Fetch();

            Assert.AreEqual(fetchedArray, new int[3] { 1, 2, 3 }, "Fetch method doesn't return the correct DB state.");
        }
    }
}
