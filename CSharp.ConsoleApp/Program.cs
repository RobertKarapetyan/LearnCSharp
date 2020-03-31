using System;
using System.Threading;

namespace CSharp.ConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            BackgroundThread();
            ForeGroundThread();
            Console.WriteLine("Returning from Main");
        }

        private static void BackgroundThread()
        {
            var t = new Thread(Worker) {IsBackground = true};
            t.Start(ThreadType.Background);
        }

        private static void ForeGroundThread()
        {
            var t = new Thread(Worker);
            t.Start(ThreadType.Foreground);
        }
        
        private static void Worker(object state) 
        {
            Console.WriteLine($"Start {(ThreadType) state} worker" );
            Thread.Sleep(5000); 
            Console.WriteLine($"End {(ThreadType) state} worker" );
        }

        private enum ThreadType
        {
            Background,
            Foreground
        }
    }
}