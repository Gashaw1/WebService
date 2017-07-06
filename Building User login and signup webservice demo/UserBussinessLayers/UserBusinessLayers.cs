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

        public List<User> UserLogin()
        {

            userBuisnessbussines = new UserBusinessLayers();
            return userBuisnessbussines.returnUsers();

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
        //add new User
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

        //return expection
        public string myError()
        {
            return errorMessage;
        }
    }
}
