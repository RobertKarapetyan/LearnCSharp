using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class ThreadPoolTests
    {
        [TestMethod]
        public void ShouldAddToThreadPool()
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(4000);  // Simulating other work (10 seconds)
            Console.WriteLine("Returning from main thread");
        }
        
        [TestMethod]
        public void ShouldCreateTask()
        {
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5); // Calling QueueUserWorkItem
            new Task(ComputeBoundOp, 5).Start();             // Equivalent of preceding using Task
            Task.Run(() => ComputeBoundOp(5));               // Another equivalent
        }

        private static void ComputeBoundOp(object state) 
        {
            // This method is executed by a thread pool thread

            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000);  // Simulates other work (1 second)

            // When this method returns, the thread goes back
            // to the pool and waits for another task
        }
    }
}