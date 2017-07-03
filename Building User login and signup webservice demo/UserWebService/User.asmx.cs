using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using UserBussinessLayers;

namespace UserWebService
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    /// 

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {
        JavaScriptSerializer js;
        UserBusinessLayers bussines;

        [WebMethod(MessageName = "all user")]
        public void ReturnUser()
        {
            bussines = new UserBusinessLayers();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(bussines.UserLogin()));
        }
        //[WebMethod(MessageName = "return xml")]
        //public XmlDocument ReturnUser()
        //{      
           
           
        //    XmlDocument xDoc = new XmlDocument();
        //    XmlDeclaration xDeclaratrion = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    XmlNode root = xDoc.DocumentElement;
        //    xDoc.InsertBefore(xDeclaratrion,root);

        //    XmlNode UsersNode = xDoc.CreateElement("Users");
        //    xDoc.AppendChild(UsersNode);
          
        //    XmlNode UserID = xDoc.CreateElement("userID");           
        //    XmlAttribute userIDAttribute = xDoc.CreateAttribute("ID");
        //    userIDAttribute.Value = "1";
        //    UsersNode.Attributes.Append(userIDAttribute);

        //    XmlNode UserName = xDoc.CreateElement("userID");
        //    XmlAttribute userNameAttribute = xDoc.CreateAttribute("Username");
        //    userNameAttribute.Value = "Akal";
        //    UsersNode.Attributes.Append(userNameAttribute);

        //    return xDoc;
        //   // return  xDocument.CreateElement(bussines.UserLogin().ToString());
           
        //}
        [WebMethod(MessageName = "return by username and password")]
        public void ReturnUser(string username, string password)
        {
            bussines = new UserBusinessLayers();
            js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(bussines.userLogin(username, password).ToArray()));
        }

        [WebMethod(MessageName = "add new User")]
        public void AddNewUser(String username, string userPassword, string userEmail)
        {
            bussines = new UserBusinessLayers();
            UserDataAccess.Models.User newUser= new UserDataAccess.Models.User();
            newUser.UserName = username;
            newUser.UserPassword = userPassword;
            newUser.UserEmail = userEmail;
            string signUpResult = bussines.UserSignUp(newUser);
            
            js = new JavaScriptSerializer();
            
            //check expectin
            string expectionResult = bussines.myError();
           
            if (expectionResult != null)
            {
                Context.Response.Write(js.Serialize(expectionResult));
            }
            else
            {
                Context.Response.Write(js.Serialize(signUpResult));
            }
        }
    }
}
