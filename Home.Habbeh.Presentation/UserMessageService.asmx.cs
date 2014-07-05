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
    public class UserMessageService : System.Web.Services.WebService
    {
        [WebMethod]
        public MethodResult Ping()
        {
            return new MethodResult(false, "Hello UserMessageService!", null);
        }



        [WebMethod]
        public MethodResult FriendSendRequest(int userId, int friendId)
        {
            try
            {
                Business.UserFriend.Create(userId, friendId);
                return new MethodResult(true, "درخواست دوستی با موفقیت ارسال شد  ", null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }



        [WebMethod]
        public MethodResult FriendAcceptRequest(int id)
        {
            try
            {
                Business.UserFriend.Accept(id);
                return new MethodResult(true, "درخواست دوستی تائید شد", null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }


        [WebMethod]
        public MethodResult<TbUserFriend> FriendList(int userId)
        {
            try
            {
                List<TbUserFriend> data = Business.UserFriend.Search(userId);
                return new MethodResult<TbUserFriend>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbUserFriend>(true, e.Message, null);
            }
        }


        [WebMethod]
        public MethodResult CheckhasFriend(int userId, int friendId)
        {
            try
            {
                String state = Business.UserFriend.CheckFriend(userId, friendId);
                return new MethodResult(true, state, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }

        }
    }
}