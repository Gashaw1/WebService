using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDataAccess.DataAccess;
using UserDataAccess.Models;

namespace UserBussinessLayers
{
    public class UserBusinessLayers : UserData
    {
        int sortVal { get; set; }
        Object obj { get; set; }
        Array array { get; set; }
        ArrayList myArrayList { get; set; }
        UserBusinessLayers userBuisnessbussines { get; set; }
       
        public ArrayList UserLogin()
        {
            myArrayList = new ArrayList();
            userBuisnessbussines = new UserBusinessLayers();
            myArrayList.Add(userBuisnessbussines.returnUsers().ToList());
            return myArrayList;
        }
        //user login
        public ArrayList userLogin(string username, string password)
        {
            myArrayList = new ArrayList();
            user = new User();

            if (UserExist(username) == true)
            {
                userBuisnessbussines = new UserBusinessLayers();
                user = userBuisnessbussines.ReturnUser(username, password);
                myArrayList.Add(user);
            }
            else
            {
                user.UserName = "invalid";
                myArrayList.Add(user);

            }
            return myArrayList;
        }
        //********************************************************************************************************************************
        //adding new user
        public string UserSignUp(User user)
        {
            string conferm = "";

            userBuisnessbussines = new UserBusinessLayers();
            bool userName = userBuisnessbussines.UserExist(user.UserName);
            bool userEmail = userBuisnessbussines.EmailExist(user.UserEmail);

            if ((userName == false) && (userEmail == false))
            {

                //dataAcess.AddUser(user);

                if (userBuisnessbussines.AddUser(user) == true)
                {
                    //                    
                    conferm = "Creatring User Successed!";
                    return conferm;
                }
                else
                {
                    return " ";
                }
            }
            else
            {
                if (userName == true)
                {
                    conferm = "Uesername Inuse !";
                }


                if (userEmail == true)
                {
                    conferm = "Email inuse!";

                }

            }
            return conferm;
        }
    }
}
