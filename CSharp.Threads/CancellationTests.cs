using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class CancellationTests
    {
        [TestMethod]
        public void ShouldCancelComputation()
        {
            var cts = new CancellationTokenSource();

            // Pass the CancellationToken and the number-to-count-to into the operation
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            Thread.Sleep(2000);
            cts.Cancel();  // If Count returned already, Cancel has no effect on it
            // Cancel returns immediately, and the method continues running here...
        }

        [TestMethod]
        public void ShouldCancelAndTrigger()
        {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            cts.Token.Register(() => Console.WriteLine("Canceled 2"));

            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            Thread.Sleep(2000);
            cts.Cancel();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for (var count = 0; count < countTo; count++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break; 
                }

                Console.WriteLine(count);
                Thread.Sleep(500); 
            }

            Console.WriteLine("Count is done");

        }
    }
}