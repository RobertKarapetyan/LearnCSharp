using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class ParallelTests
    {
        [TestMethod]
        public void ShouldIterateInParallel()
        {
            var collection = new List<int>{0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 
                13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,26, 27, 28, 29, 
                30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 
                49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 
                66, 67, 68, 69, 70, 71, 72, 73, 74};

            Parallel.ForEach(collection, Console.WriteLine);
        }

        [TestMethod]
        public void ShouldGetDirectoryBytes()
        {
            var result = DirectoryBytes(@"c:\", "" , SearchOption.TopDirectoryOnly);
        }
        
        private static long DirectoryBytes(string path, string searchPattern, SearchOption searchOption) 
        {
            var files = Directory.EnumerateFiles(path, searchPattern, searchOption);
            long masterTotal = 0;

            long fileLength = 0;
            var result = Parallel.ForEach<string, long>(
                files,

                () => 0,

                (file, loopState, index, taskLocalTotal) => { // body: Invoked once per work item
                    // Get this file's size and add it to this task's running total
                    FileStream fs = null;
                    try {
                        fs = File.OpenRead(file);
                        fileLength = fs.Length;
                    }
                    catch (IOException) 
                    { /* Ignore any files we can't access */ }
                    finally
                    {
                        fs?.Dispose();
                    }
                    return taskLocalTotal + fileLength;
                },

                taskLocalTotal => 
                { // localFinally: Invoked once per task at end
                    // Atomically add this task's total to the "master" total
                    Interlocked.Add(ref masterTotal, taskLocalTotal);
                });

            return masterTotal;
        }
        
    }
}