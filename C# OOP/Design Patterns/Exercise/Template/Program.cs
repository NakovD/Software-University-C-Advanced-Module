namespace Template
{
    using Models;

    internal class Program
    {
        static void Main(string[] args)
        {
            Bread someBread = new TwelveGrain();

            someBread.Make();
        }
    }
}
