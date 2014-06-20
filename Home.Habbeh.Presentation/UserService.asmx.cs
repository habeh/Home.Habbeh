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
        public void Register(string userName, string email, string password)
        {
            TbUser user = new TbUser() { UserName = userName, Email = email, Password = password };
            Business.User.Register(user);
        }

        [WebMethod]
        public void SendForgiveInformation(string email)
        {
            Business.User.SendForgiveInformation(email);
        }

        [WebMethod]
        public TbUser Login(string userName, string password)
        {
            return Business.User.Login(userName, password);
        }

        [WebMethod]
        public TbUser GetProfile(string userName)
        {
            return Business.User.GetProfile(userName);
        }

        [WebMethod]
        public void SaveProfile(string username,string firstname, string lastname,string email,string status,string password)
        {
            TbUser user = new TbUser() 
            {UserName=username ,FirstName=firstname ,LastName=lastname ,Email=email ,Status=status ,Password=password  };
            Business.User.SaveProfile(user);
        }

        [WebMethod]
        public List<TbUser> Search(string searchText)
        {
            return Business.User.Search(searchText);
        }

        [WebMethod]
        public void ChangeStatus(string userName, int statusId)
        {
            Business.User.ChangeStatus(userName, statusId);
        }

        [WebMethod]
        public void Follow(string userName, string followerUserName)
        {
            Business.User.Follow(userName, followerUserName);
        }
    }
}