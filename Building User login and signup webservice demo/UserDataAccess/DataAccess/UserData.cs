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

        //return all default
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
            catch (Exception ex)
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
        //return tru if exits
        protected bool UserExist(string userName)
        {
            try
            {
                usereDBContext = new UsereDBContext();
                var count = (from c in usereDBContext.Users
                             where c.UserName == userName
                             select c.UserName).Count();

                if (count > 0)
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
                errorMessage = ex.Message;
                return true;
            }
        }
        //check email inuse
        //return true if exist
        protected bool EmailExist(string userNameEmail)
        {
            usereDBContext = new UsereDBContext();
            var count = (from c in usereDBContext.Users
                         where c.UserEmail == userNameEmail
                         select c.UserEmail).Count();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //return user id
        protected User ReturnUser(string userName, string userPassword)
        {

            user = new User();
            if (UserExist(userName) == true)
            {
                usereDBContext = new UsereDBContext();
                var result = from ur in usereDBContext.Users.ToList()
                             where (ur.UserName == userName && ur.UserPassword == userPassword)
                             select ur;
                foreach (User myUser in result)
                {
                    user = new User();
                    user.UserID = myUser.UserID;
                    user.UserName = myUser.UserName;
                    user.UserPassword = "";
                    user.UserEmail = "";
                    user = myUser;
                }
            }
            return user;
        }
    }
}