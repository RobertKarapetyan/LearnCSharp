using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Methods
{
    [TestClass]
    public class PartialMethodTests
    {
        [TestMethod]
        public void ShouldCallPartialMethod()
        {
            var classA = new ClassA();
            classA.GetNewId();
        }
    }
    
    public partial class ClassA  
    {  
        partial void PerformTask();  
    }  
  
    public partial class ClassA  
    {
        public Guid Id { get; set; }
        
        public void GetNewId()  
        {  
            PerformTask();
        }  
        partial void PerformTask()  
        {  
            Id = Guid.NewGuid();
        }  
    }  
}