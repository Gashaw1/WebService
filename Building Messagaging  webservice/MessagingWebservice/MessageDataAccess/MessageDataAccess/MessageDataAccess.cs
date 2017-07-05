using MessageDataAccess.Models;
using System;
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
        public string errMessages { get; set; }
        //def constructor
        public MessageDataAccess()
        {

        }
        //return all message
        protected List<Message> ReturnMessages(string senderId)
        {
            messagesList = new List<Message>();
            messageDbContext = new MessageDbContext();
            try
            {
                var result = (from r in messageDbContext.Messages
                              where r.messagSenderID == senderId
                              select r).ToList();

                if (result.Count > 0)
                {
                    foreach (Message mes in result)
                    {
                        message = new Message();
                        message.messagSenderID = mes.messagSenderID;
                        message.messageRecierID = mes.messageRecierID;
                        message.messages = mes.messages;
                        message.messageDateTime = mes.messageDateTime;
                        messagesList.Add(message);
                    }
                }
            }
            catch (Exception ex)
            {
                errMessages = ex.Message;
            }
            return messagesList;
        }
        //return message per user
        protected List<Message> ReturnMessages(string sendeId, string reciverId)
        {
            messagesList = new List<Message>();
            messageDbContext = new MessageDbContext();
            try
            {
                var result = (from r in messageDbContext.Messages
                              where r.messagSenderID == sendeId && r.messageRecierID == reciverId
                              select r).ToList();

                if (result.Count > 0)
                {
                    foreach (Message mes in result)
                    {
                        message = new Message();
                        message.messagSenderID = mes.messagSenderID;
                        message.messageRecierID = mes.messageRecierID;
                        message.messages = mes.messages;
                        message.messageDateTime = mes.messageDateTime;
                        messagesList.Add(message);
                    }
                }
            }
            catch (Exception ex)
            {
                errMessages = ex.Message;
            }
            return messagesList;
        }
        //Insert message
        protected bool InsertMessages(Message mes)
        {
            messageDbContext = new MessageDbContext();
            try
            {
                messageDbContext.Messages.Add(mes);
                int count = messageDbContext.SaveChanges();
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string erMessage = ex.Message;
                return false;
            }
        }
    }
}