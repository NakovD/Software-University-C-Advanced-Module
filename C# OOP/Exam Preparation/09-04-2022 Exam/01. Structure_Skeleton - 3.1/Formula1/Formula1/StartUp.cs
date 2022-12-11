namespace Formula1
{
    using Formula1.Core;
    using Formula1.Core.Contracts;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
