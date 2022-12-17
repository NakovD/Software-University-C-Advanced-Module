namespace NavalVessels
{
    using Core;
    using Core.Contracts;
    using System.Globalization;
    using System.Threading;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}