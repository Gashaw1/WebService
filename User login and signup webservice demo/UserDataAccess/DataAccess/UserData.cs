using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserDataAccess.Models;
using UserDataAccess.UserDBContext;


namespace UserDataAccess.DataAccess
{
    public class UserData
    {
        //ex
        public string errorMessage { get; set; }
     
        protected List<User> users { get; set; }    
        protected User user { get; set; }
        UsereDBContext usereDBContext { get; set; }
          
        //return all 
        protected List<User> returnUsers()
        {
            try
            {
                users = new List<User>();
                usereDBContext = new UsereDBContext();
                var result = from r in usereDBContext.Users.ToList()
                             select r;

                if (result.Count() > 0)
                {
                    foreach (User ur in result)
                    {
                        user = new User();
                        user.UserID = ur.UserID;
                        user.UserName = ur.UserName;
                        users.Add(user);
                    }
                    return users;
                }
                else
                {
                    //return null user
                    user = new User();
                    users.Add(user);
                    return users;
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
              
                user = new User();
                users.Add(user);
                return users;
            }
        }
        //add user
        protected bool AddUser(User user)
        {
            try
            {
                using (usereDBContext = new UsereDBContext())
                {
                    usereDBContext.Users.Add(user);

                    int x = usereDBContext.SaveChanges();
                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    

    }
}