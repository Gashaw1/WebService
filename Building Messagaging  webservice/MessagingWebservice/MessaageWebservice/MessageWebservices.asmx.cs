using MessageBusinessLayer;
using MessageDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace MessaageWebservice
{
    /// <summary>
    /// Summary description for MessageWebservices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MessageWebservices : System.Web.Services.WebService
    {

        MussageBusiness messageBusiess { get; set; }
        List<Message> messages { get; set; }

        //get all message  default
        [WebMethod(MessageName = "Default return all")]
        public List<Message> GetMessage()
        {
            messageBusiess = new MussageBusiness(new Message());
            return messageBusiess.getMessage();
        }
        //retrun all message from signle user
        [WebMethod(MessageName = "return all message from single user")]
        public List<Message> GetMessage(string yourID, string reciverID)
        {
            messageBusiess = new MussageBusiness(new Message(yourID, reciverID));
            return messageBusiess.getMessage(messageBusiess).ToList();
        }
        //retrun all message from signle user
        [WebMethod(MessageName = "return last message from single user")]
        public Message GetLastMessage(string yourID, string reciverID)
        {
            messageBusiess = new MussageBusiness(new Message(yourID, reciverID));
            return messageBusiess.getLastMessage(messageBusiess);
        }
        [WebMethod(MessageName = "send message fro single user")]
        public void sendMessagePerUser(string yourID, string reciverID, string smessage)
        {
            messageBusiess = new MussageBusiness();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(messageBusiess.sendMessage(yourID, reciverID, smessage)));

            //sendMessagesForAllReciver
        }
        [WebMethod(MessageName = "send message fro all user")]
        public void sendMessageAllUser(string yourID, string smessage)
        {
            messageBusiess = new MussageBusiness();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(messageBusiess.sendMessage(yourID, smessage)));

            //sendMessagesForAllReciver
        }
    }
}
