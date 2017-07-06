using MessageDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MessageDataAccess
{
   
    public class MessageDbContext : DbContext
    {       
        public DbSet<Message> Messages { get; set; }    
    }
}