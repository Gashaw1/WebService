using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageDataAccess.Models;
using System.Collections;
using MessageDataAccess;

namespace MessageBusinessLayer
{
    public class MussageBusiness : MessageDataAccess.MessageDataAccess.MessageDataAccess
    {
        string yourID { get; set; }
        string reciverID { get; set; }
        List<string> messageList { get; set; }
        Queue queue { get; set; }

        MussageBusiness messageBusiness { get; set; }
        public MussageBusiness()
        {

        }
        public MussageBusiness(string yourID)
        {
            this.yourID = yourID;
        }
        public MussageBusiness(Message mes)
        {
            this.yourID = mes.messagSenderID;
            this.reciverID = mes.messageRecierID;
        }
        //check reciver
        //return null if not found
        public string GetReciver(string reciverID)
        {
            messageBusiness = new MussageBusiness();
            try
            {
                if (messageBusiness.CheckReciverID(reciverID) != true)
                {
                    return reciverID;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                errMessages = ex.Message + "Method " + "GetReciver(string reciverID)";
                return null;
            }
        }
     
        //get all message (default)
        public List<Message> getMessage()
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages();
        }
        //get message from single user
        public List<Message> getMessage(MussageBusiness mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages(mes.yourID, mes.reciverID);
        }
        //get last message from a single user
        public Message getLastMessage(MussageBusiness mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnLastMessages(mes.yourID, mes.reciverID);
        }
        //sending message for a single reciver
        public bool sendMessage(string yourID, string reciverId, string messages)
        {
            try
            {
                messageBusiness = new MussageBusiness();

                //check reciver id
                if (GetReciver(reciverId) != null)
                {

                    message = new Message(yourID, reciverId, messages);
                    //message send successed
                    if (messageBusiness.InsertMessages(message) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errMessages = ex.Message;
                return false;
            }

        }
        //send message for all reciver
        //Insert messae for all reciver
        public bool sendMessage(string yourID, string mes)
        {
            //get all reciverids
            var recivers = (from r in ReturnReciverIDs()
                            select r).ToArray();

            for (int i = 0; i < recivers.Length; i++)
            {
                //get reciver id
                string reciverId = recivers[i].ToString();

                message = new Message();
                message.messagSenderID = yourID;
                message.messageRecierID = reciverId;
                message.messages = mes;
                //invo method
                InsertMessages(message);
            }
            return true;
        }
        //public void get
    }

}
