namespace ChristmasPastryShop
{
    using ChristmasPastryShop.Core;
    using ChristmasPastryShop.Core.Contracts;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
