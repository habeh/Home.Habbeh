using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Home.Habbeh.Entity;
using Home.Habbeh.Entity.Common;

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
        public MethodResult Ping()
        {
            return new MethodResult(false, "Hello UserService!", null);
        }

        [WebMethod]
        public MethodResult Register(string userName, string email, string password)
        {
            try
            {
                TbUser user = new TbUser() { UserName = userName, Email = email, Password = password };
                Business.User.Register(user);
                return new MethodResult(false, "ثبت نام با موفقیت انجام شد", null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult SendForgiveInformation(string email)
        {            
            try
            {
                Business.User.SendForgiveInformation(email);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult Login(string userName, string password)
        {
            try
            {
                TbUser user = Business.User.Login(userName, password);
                if (user != null)
                {
                    return new MethodResult(false, null, user);
                }
                else
                {
                    return new MethodResult(true, "نام کاربری یا رمز عبور اشتباه می باشد", null);
                }
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult GetProfile(int userid)
        {
            try
            {
                TbUser user = Business.User.GetProfile(userid);
                return new MethodResult(false, null, user);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult SaveProfile(string username, string firstname, string lastname, string email, string status)
        {
            try
            {
                TbUser user = new TbUser() { UserName = username, FirstName = firstname, LastName = lastname, Email = email, Status = status };
                Business.User.SaveProfile(user);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult<TbUser> Search(string searchText)
        {
            try
            {
                List<TbUser> data = Business.User.Search(searchText);
                return new MethodResult<TbUser>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbUser>(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult ChangeStatus(string userName, int statusId)
        {
            try
            {
                Business.User.ChangeStatus(userName, statusId);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult Follow(string userName, string followerUserName)
        {            
            try
            {
                Business.User.Follow(userName, followerUserName);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult ChangePassword(string userName, string oldPass, string newPass)
        {            
            try
            {
                Business.User.ChangePassword(userName, oldPass, newPass);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }
    }
}