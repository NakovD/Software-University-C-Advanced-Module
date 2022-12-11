
namespace P01.Stream_Progress
{
    using Contracts;
    using System;

    public class Video : IStreamable
    {
        public int Length { get; private set; }

        public int BytesSent { get; private set; }

        public string Creator { get; private set; }

        public Video(string creator, int length, int bytesSent)
        {
            Creator = creator;
            Length = length;
            BytesSent = bytesSent;
        }

        public void WatchVideo()
        {
            Console.WriteLine($"Watching video made from {Creator}");
        }
    }
}
