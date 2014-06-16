using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Home.Habbeh.Entity;

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
        public string Ping()
        {
            return "Hello Comment Service!";
        }

        [WebMethod]
        public void Create(int userId, int messageId, string description)
        {
            TbComment comment = new TbComment();
            comment.UserId = userId;
            comment.MessageId = messageId;
            comment.Description = description;
            comment.CommentTypeId = 1;

            Business.Comment.Create(comment);
        }

        [WebMethod]
        public List<TbComment> Retrieve(int messageId)
        {
            return Business.Comment.RetrieveList(messageId);
        }
    }
}
