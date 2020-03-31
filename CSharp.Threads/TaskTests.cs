using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void ShouldCreateTask()
        {
            var task = new Task<int>(n => Sum((int) n), 4);
            task.Start();

            // Optional
            task.Wait();
            Console.WriteLine("The Sum is: " + task.Result); 
        }

        [TestMethod]
        public void ShouldCancelTask()
        {
            var cts = new CancellationTokenSource();
            var t = Task.Run(() => Sum(cts.Token, 1000000000), cts.Token);
            cts.Cancel(); 

            try
            {
                Console.WriteLine("The sum is: " + t.Result); 
            }
            catch (AggregateException x)
            {
                x.Handle(e => e is OperationCanceledException);
                
                Console.WriteLine("Sum was canceled");
            }
        }

        [TestMethod]
        public void ShouldDetermineTaskCompletion()
        {
            var t = Task.Run(() => Sum(CancellationToken.None, 10000));
            t.ContinueWith(task => Console.WriteLine("The sum is: " + task.Result));
        }

        [TestMethod]
        public void ShouldMakeUseOfTaskOptions()
        {
            var cts = new CancellationTokenSource();
            var task = Task.Run(() => Sum(cts.Token, 1000000000), cts.Token);
            cts.Cancel();
            
            task.ContinueWith(_ => Console.WriteLine("The sum is: " + _.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(_ => Console.WriteLine("Sum threw: " + _.Exception.InnerException),
                TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(_ => Console.WriteLine("Sum was canceled"),
                TaskContinuationOptions.OnlyOnCanceled);
        }

        [TestMethod]
        public void ShouldCreateChildrenTasks()
        {
            var parent = new Task<int[]>(() => 
            { 
                var results = new int[3];

                new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();
                
                return results;
            });
            
            parent.ContinueWith(parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));

            parent.Start();
            parent.Wait();
        }

        [TestMethod]
        public void ShouldCheckStatus()
        {
            var t = Task.Run(() => Sum(CancellationToken.None, 10000));
            Console.WriteLine(t.Status);
            t.Wait();
            Console.WriteLine(t.Status);
        }
        private static Timer _sTimer;
        
        [TestMethod]
        public void ShouldSetTimeout()
        {
            _sTimer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);
            _sTimer.Change(0, Timeout.Infinite);
            Thread.Sleep(8000);
            _sTimer.Dispose();
            Thread.Sleep(8000);
        }
        
        private static void Status(object state) 
        {
            Console.WriteLine("In Status at {0}", DateTime.Now);
            Thread.Sleep(1000);
            _sTimer.Change(2000, Timeout.Infinite);
        }
        
        private static int Sum(CancellationToken ct, int n) 
        {
            var sum = 0;
            for (; n > 0; n--) {
                
                ct.ThrowIfCancellationRequested();

                checked { sum += n; }   
            }
            return sum;
        }

        private static int Sum(int n) 
        {
            var sum = 0;
            for (; n > 0; n--)
                checked { sum += n; }   
            return sum;
        }
    }
}