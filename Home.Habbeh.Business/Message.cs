using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class Message
    {
        public static void Create(TbMessage msg)
        {
            using (DataAccess.Message db = new DataAccess.Message())
            {
                msg.RegisterDate = DateTime.Now;
                db.Create(msg);
            }
        }

        public static List<TbMessage> ReadMessage(String lastUpdateMessage)
        {
            using (DataAccess.Message db = new DataAccess.Message())
            {
                return db.RetrieveList(lastUpdateMessage);
            }
        }


        public static int CountNewMessage(string LastReadMessage)
        {
            using (DataAccess.Message db = new DataAccess.Message())
            {
                return db.CountNewMessage(LastReadMessage);
            }
        }
    }
}
