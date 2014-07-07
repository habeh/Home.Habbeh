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
        public MethodResult Create(int userId,int reportuserId, int messageId, string description, int CommenttypeId)
        {
            try
            {
                TbComment comment = new TbComment();
                
                String SetDecription = "این کاربر تخلف کرده است. لطفا بررسی شود";
                if (CommenttypeId.Equals(2))
                {
                    comment.ReportUserId = reportuserId;
                    description = SetDecription.ToString();
                    return new MethodResult(true, "کاربر گرامی : گرازش تخلف شما در مورد این کاربر به موفقیت به دست ما رسید. بعد از بررسی در اسرع وقت اقدام می شود. با تشکر", null);
                }
                comment.UserId = userId;
                comment.MessageId = messageId;
                comment.Description = description;
                comment.CommentTypeId = CommenttypeId;

                Business.Comment.Create(comment);
                return new MethodResult(true, " نظر ارسالی با موفقیت ثبت شد ", null);
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
