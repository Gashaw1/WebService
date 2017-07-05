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
        string senderID { get; set; }
        string reciverID { get; set; }
        List<string> messageList { get; set; }
        Queue queue { get; set; }

        MussageBusiness messageBusiness { get; set; }
        public MussageBusiness()
        {
            
        }
        public MussageBusiness(string senderID)
        {
            this.senderID = senderID;
        }
        public MussageBusiness(Message mes)
        {
            this.senderID = mes.messagSenderID;
            this.reciverID = mes.messageRecierID;
        }    
        //
        public List<Message> getMessage(MussageBusiness mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages(mes.senderID, mes.reciverID);          
        }
        public bool sendMessage(string senderId,string reciverId, string messages)
        {
            messageBusiness = new MussageBusiness();
            message = new Message(senderId, reciverId,messages);
            messageBusiness.InsertMessages(message);

            return true;
        }
    }
}
