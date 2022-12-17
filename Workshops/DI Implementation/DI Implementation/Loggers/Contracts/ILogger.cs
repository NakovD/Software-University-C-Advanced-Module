namespace DI_Implementation.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string message);

        void Warn(string message);

        void Error(string message);

        void Fatal(string message);
    }
}
