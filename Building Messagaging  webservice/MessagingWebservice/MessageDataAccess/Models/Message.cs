﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MessageDataAccess.Models
{
    [Table("Message")]
    public class Message
    {

        [Required]
        [Key]
        public int messageID { get; set; }
        public string messages { get; set; }      
        public string messagSenderID { get; set; }
        public string messageRecierID { get; set; }
        public DateTime messageDateTime;

        public Message()
        {
        }
        public Message(string messagSenderID)
        {
            this.messagSenderID = messagSenderID;
        }
        public Message(string messagSenderID, string messageRecierID)
        {
            this.messagSenderID = messagSenderID;
            this.messageRecierID = messageRecierID;
        }
        public Message(string messagSenderID, string messageRecierID, string messages)
        {
            this.messagSenderID = messagSenderID;
            this.messageRecierID = messageRecierID;
            this.messages = messages;
        }
        public void Date()
        {
            messageDateTime = DateTime.Now;
        }

        //[Index(IsUnique = true)]
        //[MaxLength(255)] // for code-first implementations
        //public string UserName { get; set; }

    }
}