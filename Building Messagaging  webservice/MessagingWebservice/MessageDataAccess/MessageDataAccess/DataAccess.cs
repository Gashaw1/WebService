﻿using MessageDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageDataAccess.MessageDataAccess
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
        protected List<Message> ReturnMessages()
        {
            messagesList = new List<Message>();
            messageDbContext = new MessageDbContext();
            try
            {
                var result = (from r in messageDbContext.Messages
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
        //return all message for a single user
        protected List<Message> ReturnMessages(string yourId)
        {
            messagesList = new List<Message>();
            messageDbContext = new MessageDbContext();
            try
            {
                var result = (from r in messageDbContext.Messages
                              where r.messagSenderID == yourId
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
        //return all message from sing user
        protected List<Message> ReturnMessages(string yourId, string reciverId)
        {
            messagesList = new List<Message>();
            messageDbContext = new MessageDbContext();
            try
            {
                var result = (from r in messageDbContext.Messages
                              where r.messagSenderID == yourId && r.messageRecierID == reciverId
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
        //return last message from single user
        protected Message ReturnLastMessages(string yourId, string reciverId)
        {
            messageDbContext = new MessageDbContext();
            message = new Message();
            try
            {
                var result = (from r in messageDbContext.Messages
                              where r.messagSenderID == yourId && r.messageRecierID == reciverId
                              select r).ToList();
                if (result.Count > 0)
                {
                    var resutLast = (from r in result
                                     select r).Last();

                    message.messagSenderID = resutLast.messagSenderID;
                    message.messageRecierID = resutLast.messageRecierID;
                    message.messages = resutLast.messages;
                }

            }
            catch (Exception ex)
            {
                errMessages = ex.Message;
            }
            return message;
        }
        //return all reciverId
        protected string[] ReturnReciverIDs()
        {

            messageDbContext = new MessageDbContext();
            message = new Message();

            var resultSenderID = (from r in messageDbContext.Messages
                                  select r.messageRecierID).Distinct().ToArray();
            return resultSenderID;
        }
        //Insert message single reciver
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
        ////check rciverIDs
        ////return true if exist
        //protected bool CheckReciverID(string reciverID)
        //{
        //    try
        //    {
        //        messageDbContext = new MessageDbContext();

        //        var resultReciverID = (from reiverids in messageDbContext.Messages
        //                               where reiverids.messageRecierID == reciverID
        //                               select reiverids.messageRecierID).Distinct();

        //        if (resultReciverID.Any())
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errMessages = ex.Message;
        //        return false;
        //    }
        //}
    }
}