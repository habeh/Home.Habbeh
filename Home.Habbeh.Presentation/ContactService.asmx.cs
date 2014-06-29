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
    /// Summary description for ContactService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ContactService : System.Web.Services.WebService
    {

        [WebMethod]
        public MethodResult Ping()
        {
            return new MethodResult(false, "Hello Contact Service", null);
        }

        [WebMethod]
        public MethodResult Create(int userId, string description)
        {
            try
            {
                TbContact contact = new TbContact();
                contact.UserId = userId;
                contact.Description = description;
                Business.Contact.Create(contact);
                return new MethodResult(false, null, null);
            }
            catch (HabbeException e)
            {
                return new MethodResult(true, e.Message, null);
            }
        }
    }
}
