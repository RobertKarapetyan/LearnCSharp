using System;

namespace CSharp.ExceptionsAndStateManagement
{
    internal class UiStuff
    {
        public string DisplayDivisionResults(int n1, int n2)
        {
            string result;
            
            try
            {
                Utility<int>.Divide(n1, n2);
                result = "WillDisplayUI";
            }
            catch (Exception e)
            {
                result = $"WillNotDisplayUI";
                (e as IException)?.PrintDetails();
            }

            return result;
        }
    }
}