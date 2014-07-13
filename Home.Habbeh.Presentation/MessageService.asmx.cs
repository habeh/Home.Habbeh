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
    /// Summary description for MessageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MessageService : System.Web.Services.WebService
    {

        [WebMethod]
        public MethodResult Ping()
        {
            return new MethodResult(false, "Hello Message Service!", null);
        }

        [WebMethod]
        public MethodResult InsertMessage(int categoryId, int userId, string description)
        {
            try
            {
                TbMessage msg = new TbMessage();
                msg.CategoryId = categoryId;
                msg.UserId = userId;
                msg.Description = description;

                Business.Message.Create(msg);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult LikeMessage(int userId, int messageId)
        {
            try
            {
                TbLike like = new TbLike();
                like.UserId = userId;
                like.MessageId = messageId;
                like.Rank = 1;

                bool data = Business.Like.Create(like);
                return new MethodResult(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult<TbMessage> ReadMessage(String lastUpdateMessage)
        {
            try
            {
                List<TbMessage> data = Business.Message.ReadMessage(lastUpdateMessage);
                return new MethodResult<TbMessage>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbMessage>(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult CountNewMessage(String LastReadMessage)
        {
            try
            {
                int data = Business.Message.CountNewMessage(LastReadMessage);
                return new MethodResult(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult CountLike(int messageid)
        {
            try
            {
                int data = Business.Like.CountLike(messageid);
                return new MethodResult(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult<TbCategory> RetrieveCategoryList()
        {
            try
            {
                List<TbCategory> data = Business.Category.RetrieveList();
                return new MethodResult<TbCategory>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbCategory>(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult<TbCategory> RetrieveCategoryUsedList()
        {
            try
            {
                List<TbCategory> data = Business.Category.RetrieveUsedList();
                return new MethodResult<TbCategory>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbCategory>(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult SendMessage(int messageId)
        {
            try
            {
                Business.Message.SendMessage(messageId);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }


        [WebMethod]
        public MethodResult<TbMessage> ReadUserMessage(int userId)
        {
            try
            {
                List<TbMessage> data = Business.Message.ReadUserMessage(userId);
                return new MethodResult<TbMessage>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbMessage>(true, e.Message, null);
            }
        }
    }
}
