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
    /// Summary description for JsonMessageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class JsonMessageService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string ReadMessage(String lastUpdateMessage)
        {
            try
            {
                List<TbMessage> data = Business.Message.ReadMessage(lastUpdateMessage);
                return JsonHelper.JsonSerializer<MethodResult>(new MethodResult(false, null, data));
            }
            catch (HabbeException e)
            {
                return JsonHelper.JsonSerializer<MethodResult>(new MethodResult(true, e.Message, null));
            }
        }
    }
}
