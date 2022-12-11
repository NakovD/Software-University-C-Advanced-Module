namespace P02_BlackBoxInteger.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(object value);

        void Write(object value);
    }
}
