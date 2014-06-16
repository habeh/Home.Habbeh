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
    }
}
