using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageDataAccess.Models;
namespace MessageBusinessLayer
{
    class MussageBusiness: MessageDataAccess.MessageDataAccess
    {
        MussageBusiness messageBusiness { get; set; }
        public Message[] getMessage()
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages().ToArray();
        }
        public Message[] getMessage(Message mes)
        {
            messageBusiness = new MussageBusiness();
            return messageBusiness.ReturnMessages(mes.messagSenderID, mes.messageRecierID).ToArray();
        }
        public void sendMessage()
        {
            messageBusiness = new MussageBusiness();
            messageBusiness.AddMessages(message);

        }

    }
}
