using System;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class ExecutionContextTests
    {
        [TestMethod]
        public void ShouldModifyThreadContext()
        {
            CallContext.SetData("Name", "Jeffrey");
            
            ThreadPool.QueueUserWorkItem(
                state => Console.WriteLine("Name={0}", CallContext.GetData("Name")));
            
            ExecutionContext.SuppressFlow();
            
            ThreadPool.QueueUserWorkItem(
                state => Console.WriteLine("Name={0}", CallContext.GetData("Name")));
            
            ExecutionContext.RestoreFlow();
        }
        
        private static class CallContext
        {
            private static readonly ConcurrentDictionary<string, AsyncLocal<object>> State = 
                new ConcurrentDictionary<string, AsyncLocal<object>>();
            
            public static void SetData(string name, object data) =>
                State.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;
            
            public static object GetData(string name) =>
                State.TryGetValue(name, out var data) ? data.Value : null;
        }
    }
}