using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Events
{
    [TestClass]
    public class EventTests
    {
        private readonly Person _robert;
        private readonly Person _manish;
        private readonly Person _david;

        public EventTests()
        { 
            _robert = new Person("Robert");
            _manish = new Person("Manish");
            _david = new Person("David");
            
            ChatApp.SendGroupTextEvent += _manish.RecieveGroupText;
            ChatApp.SendGroupTextEvent += _david.RecieveGroupText;
            ChatApp.SendGroupTextEvent += _robert.RecieveGroupText;
        }
        
        [TestMethod]
        public void ShouldSendMessage()
        {
            _robert.SendGroupText("Hello from Robert");
            _manish.SendGroupText("Hello from Manish");
            _david.SendGroupText("Hello from David");
            
            Assert.AreEqual(_robert.ChatLog, _manish.ChatLog);
            Assert.AreEqual(_manish.ChatLog, _david.ChatLog);
        }
    }
    
    internal sealed class Person
    {
        private string _chatLog; public string ChatLog => _chatLog;

        public Person(string name)
        {
            _chatLog = "Common Chat Log:";
        }
        public void SendGroupText(string message)
        {
            var groupTextEventArgs = new GroupText(message);
            ChatApp.SendGroupText(this, groupTextEventArgs);
        }
            
        public void RecieveGroupText(object sender, GroupText groupText)
        {
            _chatLog += Environment.NewLine + groupText.Body;
        }
    }

    internal class GroupText : EventArgs
    {
        public string Body { get; }

        public GroupText(string body)
        {
            Body = body;
        }
    }

    internal static class ChatApp
    {
        public static event EventHandler<GroupText> SendGroupTextEvent;

        public static void SendGroupText(object o, GroupText groupText)
        {
            Volatile.Read(ref SendGroupTextEvent)?.Invoke(o, groupText);
        }
    }
}