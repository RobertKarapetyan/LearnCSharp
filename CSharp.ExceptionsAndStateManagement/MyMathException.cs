using System;

namespace CSharp.ExceptionsAndStateManagement
{
    internal class MyMathException : Exception, IException
    {
        public override string Message { get; }

        private Exception Actual { get;  }

        public MyMathException(Exception exception)
        {
            Actual = exception;
            Message = $"Could not perform math operation";
        }

        public void PrintDetails()
        {
            Console.WriteLine(Actual.GetType());
            Console.WriteLine(Actual.Message);
            Console.WriteLine(Actual.StackTrace);
        }
    }
    
    internal interface IException
    {
        void PrintDetails();
    }
}