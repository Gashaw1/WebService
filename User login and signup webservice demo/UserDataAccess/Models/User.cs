using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserDataAccess.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
        }
        [Required]
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
       
    }
}