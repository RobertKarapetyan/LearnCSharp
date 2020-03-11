using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Interfaces
{
    [TestClass]
    public class VarianceTests
    {
        [TestMethod]
        public void ShouldGetMediumForEmail()
        {
            var messenger = new Messenger<EmailMessage>(new EmailMessage());
            Assert.AreEqual(Medium.Email, GetMedium(messenger));
        }
        
        [TestMethod]
        public void ShouldGetMediumForPhone()
        {
            var messenger = new Messenger<TextMessage>(new TextMessage());
            Assert.AreEqual(Medium.Phone, GetMedium(messenger));
        }

        private static Medium GetMedium(IMessenger<Message> messenger)
        {
            var result = messenger.Message().Medium();
            return result;
        }
    }

    internal interface IMessenger<out T> 
    {
        T Message();
    }

    internal class Messenger<T> : IMessenger<T> where T : IMessage, new()
    {
        private readonly T _message;
        public Messenger(T message)
        {
            _message = message;
        }
        
        public T Message()
        {
            return _message;
        }
    }

    internal interface IMessage
    {
        string MessageBody();

        Medium Medium();
    }

    enum Medium
    {
        Email, Phone
    }

    internal class Message : IMessage
    {
        private readonly string _messageBody;
        
        public Message(string messageBody)
        {
            _messageBody = messageBody;
        }

        protected Message()
        {
           
        }

        public virtual string MessageBody()
        {
            var result = _messageBody;
            return result;
        }

        public virtual Medium Medium()
        {
            throw new System.NotImplementedException();
        }

        public virtual string ContactInfo { get; set; }
    }
    
    internal class EmailMessage : Message
    {
        public override string ContactInfo { get; set; } = "abcd@mail.com";

        public EmailMessage()
        {
        }
        
        public override Medium Medium()
        {
            return Interfaces.Medium.Email;
        }
    }

    internal class TextMessage : Message
    {
        public override string ContactInfo { get; set; } = "123 456 7891";

        public override Medium Medium()
        {
            return Interfaces.Medium.Phone;
        }
        
        public TextMessage() { }
    }
}