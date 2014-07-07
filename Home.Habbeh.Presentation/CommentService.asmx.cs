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
    /// Summary description for CommentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CommentService : System.Web.Services.WebService
    {
        [WebMethod]
        public MethodResult Ping()
        {
            return new MethodResult(false, "Hello Comment Service", null);
        }

        [WebMethod]
        public MethodResult Create(int userId, int offendingUserId, int messageId, string description, int commentTypeId)
        {
            try
            {
                TbComment comment = new TbComment();
                String SetDecription = "این کاربر تخلف کرده است. لطفا بررسی شود";

                comment.UserId = userId;
                comment.Description = description;
                comment.CommentTypeId = commentTypeId;
                if (commentTypeId.Equals(2))
                {
                    comment.OffendingUserId = offendingUserId;
                    comment.Description = SetDecription;
 
                }
                else
                {
                    comment.MessageId = messageId;
                }

                Business.Comment.Create(comment);
                return new MethodResult(false, " نظر ارسالی با موفقیت ثبت شد ", null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }

        [WebMethod]
        public MethodResult<TbComment> Retrieve(int messageId)
        {
            try
            {
                List<TbComment> data = Business.Comment.RetrieveList(messageId);
                return new MethodResult<TbComment>(false, null, data);
            }
            catch (HabbeException e)
            {
                return new MethodResult<TbComment>(true, e.Message, null);
            }
        }
    }
}
