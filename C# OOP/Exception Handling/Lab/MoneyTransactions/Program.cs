using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MoneyTransactions
{
    public class Program
    {
        private static List<BankAccount> bankAccounts = new List<BankAccount>();
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ParseBankAccountsData();
            ReadLines();
        }

        private static void ReadLines()
        {
            var line = Console.ReadLine();
            if (line == "End") return;

            var (command, accountNumber, sum) = ParseLine(line);

            try
            {
                ReadCommand(command, accountNumber, sum);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Enter another command");

            ReadLines();
        }

        private static void ReadCommand(string command, int accountNumber, double sum)
        {
            switch (command)
            {
                case "Deposit":
                    DepositMoney(accountNumber, sum);
                    break;
                case "Withdraw":
                    WithdrawMoney(accountNumber, sum);
                    break;
                default: throw new ArgumentException("Invalid command!");
            }
        }

        private static void WithdrawMoney(int accountNumber, double withdrawAmount)
        {
            var (doesAccountExist, account) = ValidateAccount(accountNumber);
            if (!doesAccountExist) throw new ArgumentException("Invalid account!");
            var isWithdrawBiggerThanBalance = account.Balance < withdrawAmount;
            if (isWithdrawBiggerThanBalance) throw new ArgumentException("Insufficient balance!");
            account.WithdrawMoney(withdrawAmount);
            Console.WriteLine(account);
        }

        private static void DepositMoney(int accountNumber, double sum)
        {
            var (doesAccountExist, account) = ValidateAccount(accountNumber);
            if (!doesAccountExist) throw new ArgumentException("Invalid account!");
            account.DepositMoney(sum);
            Console.WriteLine(account);
        }

        private static (bool, BankAccount) ValidateAccount(int accountNumber)
        {
            var neededAccount = bankAccounts.SingleOrDefault(ba => ba.AccountNumber == accountNumber);

            if (neededAccount == null) return (false, null);

            return (true, neededAccount);
        }

        private static (string command, int accountNumber, double sum) ParseLine(string line)
        {
            var lineCollection = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var command = lineCollection[0];
            var accountNumber = int.Parse(lineCollection[1]);
            var sum = double.Parse(lineCollection[2]);

            return (command, accountNumber, sum);
        }

        private static void ParseBankAccountsData()
        {
            var unparsedBankAccountsData = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in unparsedBankAccountsData)
            {
                var unparsedBankAccountData = item.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var accountNumber = int.Parse(unparsedBankAccountData[0]);
                var accountBalance = double.Parse(unparsedBankAccountData[1]);
                var bankAccount = new BankAccount(accountNumber, accountBalance);
                bankAccounts.Add(bankAccount);
            }

        }
    }

    public class BankAccount
    {
        public int AccountNumber { get; private set; }

        public double Balance { get; private set; }

        public BankAccount(int accountNumber, double balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void DepositMoney(double amount)
        {
            this.Balance += amount;
        }

        public void WithdrawMoney(double amount)
        {
            Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {AccountNumber} has new balance: {Balance:F2}";
        }
    }
}
