using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
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

        //XDocument xDecumentss;

        //[WebMethod(MessageName = "all user")]
        //public XmlDocument ReturnUser()
        //{
        //    bussines = new UserBusinessLayers();
        //    XmlComment xDoucmet = new XmlComment();
        //    //return bussines.UserLogin()XmlComment;
        //    return xDoucmet.CreateElement(bussines.UserLogin().ToString());
        //    //JavaScriptSerializer js = new JavaScriptSerializer();
        //    //Context.Response.Write(js.Serialize(bussines.UserLogin()));
        ////}
        //[WebMethod(MessageName = "return xml")]
        //public XmlDocument ReturnUser()
        //{
        //    bussines = new UserBusinessLayers();
        //    var res = from r in bussines.UserLogin()
        //              select r;

        //    XmlDocument x = new XmlDocument();
        //    XmlDeclaration xDeclaration = new XmlDeclaration();
        //    XmlElement xelement = new XmlElement();
        //    xelement.

           
           
        //    //foreach (var v in res)
        //    //{

        //    //    XDocument xDecumentss = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
        //    //   new XComment("xml userDocument"),
        //    //   new XElement("Users",
        //    //       new XElement("User", new XAttribute("UserID", v.UserID),
        //    //           new XElement("Username", v.UserName),
        //    //           new XElement("UserEmail", v.UserEmail)
        //    //   )));
        //    //    x = xDecumentss;
        //    //}
        //    return x;

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
            UserDataAccess.Models.User newUser = new UserDataAccess.Models.User();
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
