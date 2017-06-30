using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using UserBussinessLayers;

namespace UserWebService
{
    /// <summary>
    /// Summary description for User
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class User : System.Web.Services.WebService
    {

      
       
        UserBusinessLayers bussines;   
      
        [WebMethod(MessageName = "all user")]
        public void ReturnUser()
        {
            bussines = new UserBusinessLayers();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(bussines.UserLogin()));
        }


        [WebMethod(MessageName = "return by username and password")]
        public void ReturnUser(string username, string password)
        {
            bussines = new UserBusinessLayers();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(bussines.userLogin(username, password).ToArray()));

        }
    }
}
