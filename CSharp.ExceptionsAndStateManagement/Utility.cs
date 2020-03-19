using System;

namespace CSharp.ExceptionsAndStateManagement
{
    internal class Utility<T>
    {
        public static Utility<T> CreateInstance()
        {
            return new Utility<T>();
        }

        public static T Divide(dynamic n1, dynamic n2)
        {
            T result; 
            try
            {
                result = n1 / n2;
            }
            catch (Exception e)
            {
                throw new MyMathException(e);
            }

            return result;
        }
    }
}