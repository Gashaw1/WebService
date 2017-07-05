using MessageDataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace MessageDataAccess
{
    public class MessageDataAccess : Message
    {
        protected MessageDataAccess messageDataAccess { get; set; }
        protected MessageDbContext messageDbContext { get; set; }
        protected Message message { get; set; }
        protected List<Message> messagesList { get; set; }

        public MessageDataAccess()
        {

        }
        protected Message[] ReturnMessages()
        {
            messageDbContext = new MessageDbContext();
            return messageDbContext.Messages.ToArray();
        }
        //return all message
        protected Message[] ReturnMessages(string sendeId)
        {
            messageDbContext = new MessageDbContext();
            var result = (from r in messageDbContext.Messages
                          where r.messagSenderID == sendeId 
                          select r).ToArray();           
            return result;
        }
        //return message per user
        protected Message[] ReturnMessages(string sendeId, string reciverId)
        {
            messageDbContext = new MessageDbContext();
            var result = (from r in messageDbContext.Messages
                          where r.messagSenderID == sendeId && r.messageRecierID == reciverId
                          select r).ToArray();
            return result;
        }
        protected void AddMessages(Message mes)
        {
            messageDbContext = new MessageDbContext();
            messageDbContext.Messages.Add(mes);            
        }
    }
}