namespace Chainblock.Models
{
    using Contracts;
    using Utilities.Messages;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TransactionStatus = Enums.TransactionStatus;
    public class Chainblock : IChainblock
    {
        private HashSet<ITransaction> transactions;

        public int Count => transactions.Count;

        public Chainblock()
        {
            transactions = new HashSet<ITransaction>();
        }

        public void Add(ITransaction tx)
        {
            var doesTransactionExistInCollection = Contains(tx);
            var doesTransationWithSameIdExist = Contains(tx.Id);
            if (doesTransactionExistInCollection || doesTransationWithSameIdExist) throw new ArgumentException(ExceptionMessages.TransactionDuplicate);

            transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var neededTransaction = transactions.SingleOrDefault(tx => tx.Id == id);

            if (neededTransaction == null) throw new ArgumentException(ExceptionMessages.TransactionDoesNotExist);

            neededTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx) => transactions.Contains(tx);

        public bool Contains(int id)
        {
            var neededTransaction = transactions.SingleOrDefault(tx => tx.Id == id);

            if (neededTransaction == null) return false;

            return true;
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var validTransactions = transactions.Where(tx => tx.Amount >= lo && tx.Amount <= hi);

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var orderedTransactions = transactions
                                            .OrderByDescending(tx => tx.Amount)
                                            .ThenBy(tx => tx.Id);

            return orderedTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var validReceivers = transactions
                                    .Where(tx => tx.Status == status)
                                    .OrderBy(tx => tx.Amount)
                                    .Select(tx => tx.To)
                                    .ToList();

            if (validReceivers.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.ReceiversByStatusInvalid, Enum.GetName(typeof(TransactionStatus), status)));

            return validReceivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var validSenders = transactions
                                    .Where(tx => tx.Status == status)
                                    .OrderBy(tx => tx.Amount)
                                    .Select(tx => tx.From)
                                    .ToList();
            
            if (validSenders.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.SendersByStatusInvalid, Enum.GetName(typeof(TransactionStatus), status)));
           
            return validSenders;
        }

        public ITransaction GetById(int id)
        {
            var neededTransaction = transactions.SingleOrDefault(tx => tx.Id == id);

            if (neededTransaction == null) throw new InvalidOperationException(ExceptionMessages.TransactionDoesNotExist);

            return neededTransaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var validTransactions = transactions
                                            .Where(tx => tx.To == receiver && tx.Amount >= lo && tx.Amount < hi)
                                            .OrderByDescending(tx => tx.Amount)
                                            .ThenBy(tx => tx.Id)
                                            .ToList();

            if (validTransactions.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.TransactionsByReceiverAndAmountRange, receiver, lo, hi));

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var validTransactions = transactions
                                            .Where(tx => tx.From == receiver)
                                            .OrderByDescending(tx => tx.Amount)
                                            .ThenBy(tx => tx.Id)
                                            .ToList();

            if (validTransactions.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.TransactionsByReceiverInvalid, receiver));

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var validTransactions = transactions
                                            .Where(tx => tx.From == sender && tx.Amount > amount)
                                            .OrderByDescending(tx => tx.Amount)
                                            .ToList();

            if (validTransactions.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.TransactionsBySenderAndMinumumAmountInvalid, sender, amount));

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var validTransactions = transactions
                                            .Where(tx => tx.From == sender)
                                            .OrderByDescending(tx => tx.Amount)
                                            .ToList();

            if (validTransactions.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.TransactionsBySenderInvalid, sender));

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var validTransactions = transactions
                                        .Where(tx => tx.Status == status)
                                        .OrderByDescending(tx => tx.Amount)
                                        .ToList();

            if (validTransactions.Count == 0) throw new InvalidOperationException(string.Format(ExceptionMessages.TransactionsByStatusInvalid, Enum.GetName(typeof(TransactionStatus), status)));

            return validTransactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var validTransactions = transactions
                                            .Where(tx => tx.Status == status && tx.Amount <= amount);

            return validTransactions;
        }

        public IEnumerator<ITransaction> GetEnumerator() => transactions.GetEnumerator();

        public void RemoveTransactionById(int id)
        {
            var neededTransaction = transactions.SingleOrDefault(tx => tx.Id == id);

            if (neededTransaction == null) throw new InvalidOperationException(ExceptionMessages.TransactionDoesNotExist);

            transactions.Remove(neededTransaction);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
