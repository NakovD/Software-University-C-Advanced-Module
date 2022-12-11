namespace Chainblock.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string TransactionDuplicate = "Transaction already exists!";

        public const string TransactionDoesNotExist = "Transaction was not found in the chainblock!";

        public const string TransactionsByStatusInvalid = "No transactions by status: {0} were found!";

        public const string SendersByStatusInvalid = "No transaction senders by status: {0} were found!";

        public const string ReceiversByStatusInvalid = "No transaction receivers by status: {0} were found!";

        public const string TransactionsBySenderInvalid = "No transactions by sender: {0} were found!";

        public const string TransactionsByReceiverInvalid = "No transactions by receiver: {0} were found!";

        public const string TransactionsBySenderAndMinumumAmountInvalid = "No transactions by sender: {0} and minimum amount: {1} were found!";

        public const string TransactionsByReceiverAndAmountRange = "No transactions by receiver: {0} and amount between: {1}-{2} were found!";
    }
}
