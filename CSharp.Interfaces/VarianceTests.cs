using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Interfaces
{
    [TestClass]
    public class VarianceTests
    {
        [TestMethod]
        public void ShouldConvertTopToBottom()
        {
            IMessenger<Message> messenger; 
            
            messenger = new Messenger<EmailMessage>();
            var defaultMessage = messenger.Message();
            Assert.AreEqual("CSharp.Interfaces.EmailMessage",  
                defaultMessage.GetType().ToString());
            Assert.AreEqual("abcd@mail.com", 
                (defaultMessage as EmailMessage)?.EmailAddress);

            messenger = new Messenger<TextMessage>();;
            var textMessage = messenger.Message();
            Assert.AreEqual("CSharp.Interfaces.TextMessage", 
                textMessage.GetType().ToString());
            Assert.AreEqual("123 456 7891", 
                (textMessage as TextMessage)?.PhoneNumber);
        }
    }

    internal interface IMessenger<out T> where T : IMessage
    {
        T Message();
    }

    internal class Messenger<T> : IMessenger<T> where T : IMessage, new()
    {    
        public T Message()
        {
            var result = new T();
            return result;
        }
    }

    internal interface IMessage
    {
        string MessageBody();
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

        public string MessageBody()
        {
            var result = _messageBody;
            return result;
        }
    }
    
    internal class EmailMessage : Message
    {
        public string EmailAddress { get; set; } = "abcd@mail.com";

        public EmailMessage()
        {
        }
    }

    internal class TextMessage : Message
    {
        public string PhoneNumber { get; set; } = "123 456 7891";
        public TextMessage() { }
    }
}