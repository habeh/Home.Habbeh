using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Presentation
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {
        [WebMethod]
        public string Ping()
        {
            return "Hello User Service!";
        }

        [WebMethod]
        public void Register(string username, string email, string password)
        {
            new Business.User().Register(username, email, password);
        }

        [WebMethod]
        public void SendForgiveInformation(string email)
        {
            new Business.User().SendForgiveInformation(email);
        }

        [WebMethod]
        public TbUser Login(string username, string password)
        {
            return new Business.User().Login(username, password);
        }

        [WebMethod]
        public TbUser GetProfile(int userId)
        {
            return new Business.User().GetProfile(userId);
        }

        [WebMethod]
        public List<TbUser> Search(string searchText)
        {
            return new Business.User().Search(searchText);
        }

        [WebMethod]
        public void ChangeStatus(int userId, int statusCode, int changerUserId)
        {
            new Business.User().ChangeStatus(userId, statusCode, changerUserId);
        }

        [WebMethod]
        public void Follow(int userId, int followerId)
        {

        }
    }
}