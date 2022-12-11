namespace Chainblock.Tests
{
    using NUnit.Framework;
    using Chainblock.Models;
    using Chainblock.Enums;
    using Chainblock.Contracts;
    using System.Collections.Generic;
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;

    [TestFixture]
    public class ChainblockTest
    {
        private Chainblock chainblock;

        private List<ITransaction> transactions;

        [SetUp]
        public void SetUp()
        {
            var transactions = new List<ITransaction>()
            {
                new Transaction(1, TransactionStatus.Unauthorized, "Gosho", "Pesho", 150),
                new Transaction(2, TransactionStatus.Successfull, "Pesho", "Gosho", 250),
                new Transaction(3, TransactionStatus.Aborted, "Tosho", "Pesho", 50),
                new Transaction(4, TransactionStatus.Failed, "Pesho", "Tosho", 1000),
                new Transaction(5, TransactionStatus.Unauthorized, "Gosho", "Tosho", 10),
            };
            this.transactions = transactions;
            chainblock = new Chainblock();

            transactions.ForEach(tx => chainblock.Add(tx));
        }

        [Test]
        public void Test_CtorCreatesEmptyChainblockCollection()
        {
            var chainblock = new Chainblock();

            Assert.IsTrue(chainblock.Count == 0);
        }

        [Test]
        [TestCase(4, true)]
        [TestCase(10, false)]
        [TestCase(-5, false)]
        public void Test_ContainsByIdWorksCorrectly(int id, bool expectedResult)
        {
            var actualResult = chainblock.Contains(id);
            Assert.IsTrue(expectedResult == actualResult);
        }

        [Test]
        public void Test_ContainsByRefReturnsFalseWithNonExistentTransaction()
        {
            var newTranscation = new Transaction(10, TransactionStatus.Failed, "gpsho", "posho", 10);
            var expectedResult = chainblock.Contains(newTranscation);
            Assert.IsTrue(expectedResult == false);
        }

        [Test]
        public void Test_ContainsByRefReturnsTrueWithExistingTransaction()
        {
            var newTranscation = transactions[0];
            var expectedResult = chainblock.Contains(newTranscation);
            Assert.IsTrue(expectedResult == true);
        }

        [Test]
        public void Test_AddThrowsWhenAddingExistingTransaction()
        {
            var existingTransaction = transactions[0];

            Assert.Throws<ArgumentException>(() => chainblock.Add(existingTransaction));
        }

        [Test]
        public void Test_AddThrowsWhenAddingTransactionWithIdOfTransactionThatAlreadyExists()
        {
            var newTransactionWithExistingId = new Transaction(1, TransactionStatus.Failed, "gosho", "Pesho", 1000); ;

            Assert.Throws<ArgumentException>(() => chainblock.Add(newTransactionWithExistingId));
        }

        [Test]
        public void Test_AddAddsNewTransactionWithUniqueId()
        {
            var newTransaction = new Transaction(7, TransactionStatus.Failed, "gosho", "Pesho", 1000); ;

            var countBeforeAdding = chainblock.Count;

            chainblock.Add(newTransaction);

            var countAfterAdding = chainblock.Count;

            Assert.IsTrue(countBeforeAdding + 1 == countAfterAdding);
            Assert.IsTrue(chainblock.Contains(newTransaction));
            Assert.IsTrue(chainblock.Contains(newTransaction.Id));
        }

        [Test]
        public void Test_ChangeTransactionStatusThrowsWithIdOfNonExistentTransaction()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(10, TransactionStatus.Failed));
        }

        [Test]
        [TestCase(10000)]
        [TestCase(-100)]
        [TestCase(50)]
        public void Test_GetByIdThrowsWithIdOfNonExistentTransaction(int id)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(id));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(4)]
        [TestCase(3)]
        public void Test_GetByIdFindsCorrectTransaction(int id)
        {
            var foundTransaction = chainblock.GetById(id);
            var expectedId = id;
            var actualId = foundTransaction.Id;

            Assert.IsTrue(expectedId == actualId);
        }

        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        [TestCase(TransactionStatus.Aborted)]
        public void Test_ChangeTransactionStatusUpdatesTheStatusCorrectly(TransactionStatus newStatus)
        {
            var existingTransaction = transactions[0];
            chainblock.ChangeTransactionStatus(existingTransaction.Id, newStatus);
            existingTransaction.Status = newStatus;
        }

        [Test]
        [TestCase(150_000, 200_000)]
        [TestCase(10_000, 11_000)]
        [TestCase(2_000, 5_000)]
        public void Test_GetAllInAmountRangeReturnsEmptyCollectionWithInvalidArgs(double lo, double hi)
        {
            var result = chainblock.GetAllInAmountRange(lo, hi);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void Test_GetAllInAmountRangeReturnsCorrectCollection()
        {
            var expectedResult = new List<ITransaction>() {
                transactions[0],
                transactions[2],
                transactions[4],
            };

            var actualResult = chainblock.GetAllInAmountRange(10, 150);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_GetAllOrderedByAmountDescendingThenByIdWorksCorrectly()
        {
            var expectedResult = transactions
                                        .OrderByDescending(tx => tx.Amount)
                                        .ThenBy(tx => tx.Id);

            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(100)]
        [TestCase(5100)]
        public void Test_RemoveByIdThrowsWithIdOfNonExistentTransaction(int id)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(id));
        }

        [Test]
        public void Test_RemoveByIdRemovesCorrectlyTransaction()
        {
            var transactionToRemove = transactions[4];

            var countBeforeRemoval = chainblock.Count;
            chainblock.RemoveTransactionById(transactionToRemove.Id);
            var countAfterRemoval = chainblock.Count;

            Assert.IsTrue(countBeforeRemoval - 1 == countAfterRemoval);
            Assert.IsTrue(chainblock.Contains(transactionToRemove) == false);
            Assert.IsTrue(chainblock.Contains(transactionToRemove.Id) == false);
        }

        [Test]
        public void Test_GetAllReceiversWithSpecificTransactionStatusThrowsWhenEmptyCollections()
        {
            chainblock.RemoveTransactionById(transactions[3].Id);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        [TestCase(TransactionStatus.Aborted)]
        public void Test_GetAllReceiversWithSpecificTransactionStatusReturnsCorrectCollection(TransactionStatus status)
        {
            var expectedResult = transactions
                                    .Where(tx => tx.Status == status)
                                    .OrderBy(tx => tx.Amount)
                                    .Select(tx => tx.To)
                                    .ToList();

            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(status);

            Assert.IsTrue(expectedResult.Count == actualResult.Count());
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_GetAllSendersWithSpecificTransactionStatusThrowsWhenEmptyCollections()
        {
            chainblock.RemoveTransactionById(transactions[3].Id);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        [TestCase(TransactionStatus.Successfull)]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Unauthorized)]
        [TestCase(TransactionStatus.Aborted)]
        public void Test_GetAllSendersWithSpecificTransactionStatusReturnsCorrectCollection(TransactionStatus status)
        {
            var expectedResult = transactions
                                    .Where(tx => tx.Status == status)
                                    .OrderBy(tx => tx.Amount)
                                    .Select(tx => tx.From)
                                    .ToList();

            var actualResult = chainblock.GetAllSendersWithTransactionStatus(status);

            Assert.IsTrue(expectedResult.Count == actualResult.Count());
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("Halio", 10, 150)]
        [TestCase("Gosho", 5, 9)]
        [TestCase("Pesho", 10_000, 90_000)]
        public void Test_GetByReceiverAndAmountRangeThrowsWithInvalidArgs(string receiver, double lo, double hi)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange(receiver, lo, hi));
        }

        [Test]
        [TestCase("Gosho", 150, 450)]
        [TestCase("Pesho", 50, 250)]
        [TestCase("Tosho", 150, 1050)]
        public void Test_GetByReceiverAndAmountRangeReturnsCorrectCollection(string receiver, double lo, double hi)
        {
            var expectedResult = transactions
                                        .Where(tx => tx.To == receiver && tx.Amount >= lo && tx.Amount < hi)
                                        .OrderByDescending(tx => tx.Amount)
                                        .ThenBy(tx => tx.Id)
                                        .ToList();

            var actualResult = chainblock.GetByReceiverAndAmountRange(receiver, lo, hi);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("Tanq")]
        [TestCase("Goshko")]
        public void Test_GetByReceiverOrderedByAmountThenByIdThrowsWithNonExistentReceiver(string receiver)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById(receiver));
        }

        [Test]
        [TestCase("Tosho")]
        [TestCase("Pesho")]
        public void Test_GetByReceiverOrderedByAmountReturnsCorrectCollection(string receiver)
        {
            var expectedResult = transactions
                                           .Where(tx => tx.From == receiver)
                                           .OrderByDescending(tx => tx.Amount)
                                           .ThenBy(tx => tx.Id)
                                           .ToList();

            var actualResult = chainblock.GetByReceiverOrderedByAmountThenById(receiver);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("Tanq", 10)]
        [TestCase("Gosho", 1001)]
        public void Test_GetBySenderAndMinimumAmountDescendingThrowsWithInvalidArgs(string sender, double minimum)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending(sender, minimum));
        }

        [Test]
        [TestCase("Gosho", 50)]
        [TestCase("Pesho", 249)]
        [TestCase("Pesho", 950)]
        public void Test_GetBySenderAndMinimumAmountDescendingReturnsCorrectCollection(string sender, double minimum)
        {
            var expectedResult = transactions
                                           .Where(tx => tx.From == sender && tx.Amount > minimum)
                                           .OrderByDescending(tx => tx.Amount)
                                           .ToList();

            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending(sender, minimum);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("Gorolomnik")]
        [TestCase("Tisho")]
        public void Test_GetBySenderOrderedByAmountDescendingThrowsWithInvalidArgs(string sender)
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending(sender));
        }


        [Test]
        [TestCase("Gosho")]
        [TestCase("Pesho")]
        [TestCase("Tosho")]
        public void Test_GetBySenderOrderedByAmountDescendingReturnsCorrectCollection(string sender)
        {
            var expectedResult = transactions
                                           .Where(tx => tx.From == sender)
                                           .OrderByDescending(tx => tx.Amount)
                                           .ToList();

            var actualResult = chainblock.GetBySenderOrderedByAmountDescending(sender);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_GetByTransactionStatusThrowsWithInvalidArg()
        {
            chainblock.RemoveTransactionById(transactions[3].Id);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Failed)); 
        }

        [Test]
        [TestCase(TransactionStatus.Failed)]
        [TestCase(TransactionStatus.Aborted)]
        [TestCase(TransactionStatus.Unauthorized)]
        [TestCase(TransactionStatus.Successfull)]
        public void Test_GetByTransactionStatusReturnsCorrectCollection(TransactionStatus status)
        {
            var expectedResult = transactions
                                        .Where(tx => tx.Status == status)
                                        .OrderByDescending(tx => tx.Amount)
                                        .ToList();

            var actualResult = chainblock.GetByTransactionStatus(status);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(TransactionStatus.Successfull, 10)]
        [TestCase(TransactionStatus.Failed, 150)]
        public void Test_GetByTransactionStatusAndMaximumAmountReturnsEmptyCollectionWithInvalidArgs(TransactionStatus status, double maximum)
        {
            var result = chainblock.GetByTransactionStatusAndMaximumAmount(status, maximum);

            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [TestCase(TransactionStatus.Failed, 1500)]
        [TestCase(TransactionStatus.Successfull, 300)]
        [TestCase(TransactionStatus.Unauthorized, 150)]
        public void Test_GetByTransactionStatusAndMaximumAmountReturnsCorrectCollection(TransactionStatus status, double maximum)
        {
            var expectedResult = transactions.Where(tx => tx.Status == status && tx.Amount <= maximum);

            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(status, maximum);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

    }
}
