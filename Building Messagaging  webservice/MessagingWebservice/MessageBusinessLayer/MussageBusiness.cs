using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageDataAccess.Models;
using System.Collections;

namespace MessageBusinessLayer
{
    public class MussageBusiness : MessageDataAccess.MessageDataAccess
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
        //
        public List<Message> getMessage(MussageBusiness mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages(mes.yourID, mes.reciverID);
        }
        //
        public Message getLastMessage(MussageBusiness mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnLastMessages(mes.yourID, mes.reciverID);
        }
        public bool sendMessage(string yourID, string reciverId, string messages)
        {
            messageBusiness = new MussageBusiness();
            message = new Message(yourID, reciverId, messages);
            try
            {
                if (messageBusiness.InsertMessages(message) == true)
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
                errMessages = ex.Message;
                return false;
            }

        }
    }
}
