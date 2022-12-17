namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int databaseCapacity = 16;

        private Database database = new Database();

        private Person basePerson = new Person(12, "Gosho");

        [Test]
        public void Test_DatabaseCtorFillsDB()
        {
            database = new Database(basePerson);

            var firstPersonInDb = database.FindById(12);

            var message = "DB doesn't add people correctly.";

            Assert.AreSame(basePerson, firstPersonInDb, message);
        }

        [Test]
        public void Test_DatabaseCtorThrowsWhenAddingPersonWithSameName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(basePerson, new Person(14, "Gosho"));
            }, "DB doesn't throw when adding the person with already existing name.");
        }

        [Test]
        public void Test_DatabaseCtorThrowsWhenAddingPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database = new Database(basePerson, new Person(12, "tore"));
            }, "DB doesn't throw when adding the person with already existing id.");
        }

        [Test]
        public void Test_DatabaseLengthCtor()
        {
            var people = new Person[]
            {
                basePerson,
                new Person(15, "Tonko")
        };

            database = new Database(people);

            Assert.IsTrue(database.Count == people.Length, "DB doesn't add multiple people correctly.");
        }

        [Test]
        public void Test_DatabaseCtorAddingDataBiggerThatDBCapacity()
        {
            var people = new Person[]
            {
                new Person(1, "gosho"),
                new Person(2, "gosho1"),
                new Person(3, "gosho2"),
                new Person(4, "gosho3"),
                new Person(5, "gosho4"),
                new Person(6, "gosho5"),
                new Person(7, "gosho6"),
                new Person(8, "gosho7"),
                new Person(9, "gosho8"),
                new Person(10, "gosho9"),
                new Person(11, "gosho10"),
                new Person(12, "gosho11"),
                new Person(13, "gosho12"),
                new Person(14, "gosho13"),
                new Person(15, "gosho14"),
                new Person(16, "gosho15"),
                new Person(17, "Tonko"),
            };

            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(people);
            }, $"DB constructor doesn't throw when adding data bigger than the DB capacity - {databaseCapacity}");

        }

        [Test]
        public void Test_AddMethodThrowsWhenDbIsFull()
        {
            var people = new Person[]
            {
                new Person(1, "gosho"),
                new Person(2, "gosho1"),
                new Person(3, "gosho2"),
                new Person(4, "gosho3"),
                new Person(5, "gosho4"),
                new Person(6, "gosho5"),
                new Person(7, "gosho6"),
                new Person(8, "gosho7"),
                new Person(9, "gosho8"),
                new Person(10, "gosho9"),
                new Person(11, "gosho10"),
                new Person(12, "gosho11"),
                new Person(13, "gosho12"),
                new Person(14, "gosho13"),
                new Person(15, "gosho14"),
                new Person(16, "gosho15"),
            };

            database = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(122, "Tonko"));
            }, $"DB doesn't throw when overflowing its limit - {databaseCapacity}");
        }

        [Test]
        public void Test_AddMethodThrowsIfPersonWithExistingNameIsAdded()
        {
            database = new Database(basePerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(basePerson);
            }, "DB doesn't throw when person with existing name is added.");
        }

        [Test]
        public void Test_AddMethodThrowsIfPersonWithExistingIdIsAdded()
        {
            database = new Database(basePerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(basePerson);
            }, "DB doesn't throw when person with already existing id is added.");
        }

        [Test]
        public void Test_AddMethodAddsInDB()
        {
            var dbCountBeforeAdd = database.Count;

            database.Add(basePerson);

            var dbCountAfterAdd = database.Count;

            var message = "DB doesn't add the new person.";

            Assert.AreNotEqual(dbCountBeforeAdd, dbCountAfterAdd, message);

            var addedPerson = database.FindById(basePerson.Id);

            Assert.AreSame(addedPerson, basePerson, message);
        }

        [Test]
        public void Test_RemoveMethodThrowsIfDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "Empty DB doesn't throw when trying to remove item.");
        }

        [Test]
        public void Test_RemoveMethodRemovesPerson()
        {
            database = new Database(basePerson);

            var dbCountBeforeRemove = database.Count;

            database.Remove();

            var dbCountAfterRemove = database.Count;

            var message = "DB doesn't remove correctly.";

            Assert.AreNotEqual(dbCountBeforeRemove, dbCountAfterRemove, message);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(basePerson.Id);
            }, message);
        }

        [Test]
        public void Test_FindByUsernameMethodThrowsIfUsernameIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(string.Empty);
            }, "DB doesn't throw when searching by username received empty string.");
        }

        [Test]
        public void Test_FindByUsernameMethodThrowsIfUsernameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(null);
            }, "DB doesn't throw when searching by username received null.");
        }

        [Test]
        public void Test_FindByUsernameMethodThrowsIfUsernameDoesntExist()
        {
            database = new Database(basePerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("Torelanko");
            }, "DB doesn't throw when searching for a username that is not in the DB.");
        }

        [Test]
        public void Test_FindByUsernameMethodThrowsIfUsernameIsNotCaseSensitive()
        {
            database = new Database(basePerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(basePerson.UserName.ToLower());
            }, "DB doesn' throw when searching by name receives case insensitive name.");
        }

        [Test]
        public void Test_FindByUsernameMethodReturnsFoundPerson()
        {
            database = new Database(basePerson);

            var foundPerson = database.FindByUsername(basePerson.UserName);

            Assert.AreSame(basePerson, foundPerson, "DB doesn't find the person when searching by name with name that actually exists in the DB.");
        }

        [Test]
        public void Test_FindByIdMethodThrowsIfIdIsBelowZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            }, "DB doesn't throw when searching by id with negative id.");
        }

        [Test]
        public void Test_FindByIdMethodThrowsWhenIdDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(9212);
            }, "DB doesn't throw when searching by Id doesn't find person with the given id.");
        }

        [Test]
        public void Test_FindByIdMethodReturnsFoundUser()
        {
            database = new Database(basePerson);

            var foundPerson = database.FindById(basePerson.Id);

            Assert.AreSame(basePerson, foundPerson, "DB doesn't found the person correctly.");
        }
    }
}