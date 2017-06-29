using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserDataAccess.Models;

namespace UserDataAccess.UserDBContext
{
    public class UsereDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}