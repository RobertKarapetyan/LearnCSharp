using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Threads
{
    [TestClass]
    public class SynchronizationTests
    {
        private LinkedList _linkedList;

        public SynchronizationTests()
        {
            _linkedList = new LinkedList();
        }

        [TestMethod]
        public void ShouldAddToLinkedListSynchronously()
        {
            AddAToNodes();
            AddBToNodes();
            _linkedList.Print();
        }

        [TestMethod]
        public void ShouldAddToLinkedListAsync()
        {
            for (var i = 0; i < 15; i++)
            {
                AddToListAsync();
            
                _linkedList.Print();
                Console.WriteLine();
                _linkedList = new LinkedList();
            }
        }

        private void AddToListAsync()
        {
            var addAToNodes = new Task(AddAToNodes);
            var addBToNodes = new Task(AddBToNodes);
            
            addBToNodes.Start();
            addAToNodes.Start();

            addAToNodes.Wait();
            addBToNodes.Wait();
        }

        private void AddAToNodes()
        {
            for (var i = 0; i < 10; i++)
            {
                _linkedList.Add(new Node($"A{i}"));
            }
        }

        private void AddBToNodes()
        {
            for (var i = 0; i < 10; i++)
            {
                _linkedList.Add(new Node($"B{i}"));
            }
        }
    }

    internal class Node
    {
        public Node Next;
        public readonly string Value;

        public Node(string value)
        {
            Value = value;
        }
    }

    internal class LinkedList
    {
        public Node Head;

        public void Add(Node node)
        {
            lock (this)
            {
                node.Next = Head;
                Head = node;
            }
        }

        public void Print()
        {
            var node = Head;

            Console.Write(node.Value);
            while (node.Next != null)
            {
                node = node.Next;
                Console.Write($", {node.Value}");
            }
        }
    }
}