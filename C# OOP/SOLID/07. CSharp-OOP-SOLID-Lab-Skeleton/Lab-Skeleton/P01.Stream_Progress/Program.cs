namespace P01.Stream_Progress
{
    using Contracts;
    using System;

    public class Program
    {
        static void Main()
        {
            IStreamable music = new Music("gosho", "tosho", 2, 2);

            IStreamable file = new File("some file", 10, 3);

            IStreamable video = new Video("8Bit-Ryan", 100, 100);

            var streamProgressInfo = new StreamProgressInfo(video);

            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());

            Music music1 = music as Music;

            music1.
        }
    }
}
