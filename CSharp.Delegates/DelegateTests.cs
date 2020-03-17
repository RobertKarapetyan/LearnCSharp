using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Delegates
{
    internal delegate void Feedback(int value);
    
    [TestClass]
    public class DelegateTests
    {
        [TestMethod]
        public void ShouldChainDelegates()
        {
            ChainDelegateDemo2(new Methods());
        }

        [TestMethod]
        public void ShouldGetInvocationList()
        {
            Action<int> action = null;
            action += Methods.FeedbackToConsole;
            action += Methods.FeedbackToMsgBox;

            var invocationList = action.GetInvocationList();
            
            Assert.AreEqual(2, invocationList.Length);
            
            foreach (var @delegate in invocationList)
            {
                @delegate?.DynamicInvoke(0);
            }
        }
        
        private static void StaticDelegateDemo() 
        {
            Counter(1, 3, null);
            Counter(1, 3, new Feedback(Methods.FeedbackToConsole));
            Counter(1, 3, new Feedback(Methods.FeedbackToMsgBox));
        }
        
        private static void InstanceDelegateDemo() 
        {
            var methods = new Methods();
            Counter(1, 3, new Feedback(methods.FeedbackToFile));
            Console.WriteLine();
        }
        
        private static void ChainDelegateDemo1(Methods methods) 
        {
            var fb1 = new Feedback(Methods.FeedbackToConsole);
            var fb2 = new Feedback(Methods.FeedbackToMsgBox);
            var fb3 = new Feedback(methods.FeedbackToFile);
            
            Feedback feedbackChain = null;
            feedbackChain = (Feedback) Delegate.Combine(feedbackChain, fb1);
            feedbackChain = (Feedback) Delegate.Combine(feedbackChain, fb2);
            feedbackChain = (Feedback) Delegate.Combine(feedbackChain, fb3);
            
            Counter(1, 2, feedbackChain);
         
            feedbackChain = (Feedback) Delegate.Remove(
                feedbackChain, 
                new Feedback(Methods.FeedbackToMsgBox));
            
            Counter(1, 2, feedbackChain);
        }
        
        private static void ChainDelegateDemo2(Methods methods) 
        {
            var fb1 = new Feedback(Methods.FeedbackToConsole);
            var fb2 = new Feedback(Methods.FeedbackToMsgBox);
            var fb3 = new Feedback(methods.FeedbackToFile);
            
            Feedback feedbackChain = null;
            feedbackChain += fb1;
            feedbackChain += fb2;
            feedbackChain += fb3;
            Counter(1, 2, feedbackChain);
            feedbackChain -= new Feedback(Methods.FeedbackToMsgBox);
            Counter(1, 2, feedbackChain);
        }
        
        private static void Counter(int from, int to, Feedback feedback) 
        {
            for (var val = from; val <= to; val++)
            {
                feedback?.Invoke(val);
            }
        }
    }

    internal class Methods
    {
        public static void FeedbackToConsole(int value) {
            Console.WriteLine("FeedbackToConsole: " + value);
        }
        
        public static void FeedbackToMsgBox(int value) 
        {
            Console.WriteLine("FeedbackToMsgBox: " + value);
        }
        
        public void FeedbackToFile(int value)
        {
            Console.WriteLine("FeedbackToFile: " + value);
        }
    }
}