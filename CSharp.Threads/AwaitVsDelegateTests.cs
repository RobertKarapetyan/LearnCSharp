using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class AwaitVsDelegateTests
    {
        private const string ResourceUrl = "http://google.com";
        
        [TestMethod]
        public void ShouldGetResources()
        {
            var x = ResourcesDefault();
            var y = ResourcesAsync();

            Console.WriteLine("Test Method Body");
            Assert.AreEqual(
                x.Result.Substring(0, 10), 
                y.Result.Substring(0, 10));
        }
        
        private static Task<string> ResourcesDefault()
        {
            var cancellationToken = new CancellationTokenSource();
            
            var httpData = new Task<HttpResponseMessage>
            (
                _ => new HttpClient().GetAsync(ResourceUrl, cancellationToken.Token).Result, 
                cancellationToken.Token
            );
            
            httpData.Start();
            
            var result  = httpData.ContinueWith
            (
                (t) => t.Result.Content.ReadAsStringAsync().Result, 
                cancellationToken.Token
            );

            Console.WriteLine("Return from ResourcesDefault");
            return result;
        }

        private static async Task<string> ResourcesAsync()
        {
            var httpData =  await new HttpClient().GetAsync(ResourceUrl);
            var result = await httpData.Content.ReadAsStringAsync();
            
            Console.WriteLine("Return from ResourcesAsync");
            return result;
        }
    }
}