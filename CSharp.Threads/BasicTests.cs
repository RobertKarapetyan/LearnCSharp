using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void ShouldStartADedicatedThreadInParallel()
        {
            var dedicatedThread = new Thread(Worker);
            dedicatedThread.Start(5);

            Console.WriteLine("Work in Main");
            Thread.Sleep(5000);
            
            Console.WriteLine("Returning from Main");
        }

        [TestMethod]
        public void ShouldWaitForTheDedicatedThread()
        {
            var dedicatedThread = new Thread(Worker);
            dedicatedThread.Start(5);
            dedicatedThread.Join();
            
            Console.WriteLine("Work in Main");
            Thread.Sleep(5000);

            Console.WriteLine("Returning from Main");
        }

        [TestMethod]
        public void ShouldCreateForegroundThread()
        {
            var t = new Thread(Worker);
            t.Start(5);
            Console.WriteLine("Returning from Main");
        }
        
        [TestMethod]
        public void ShouldCreateBackgroundThread()
        {
            var t = new Thread(Worker) {IsBackground = true};
            t.Start();
            Console.WriteLine("Returning from Main");
        }
        
        private static void Worker(object state) 
        {
            Console.WriteLine("Start Worker");
            Thread.Sleep(3000); 
            Console.WriteLine("End Worker");
        }
    }
}