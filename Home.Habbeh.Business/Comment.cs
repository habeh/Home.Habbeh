using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class Comment
    {
        public static void Create(TbComment comment)
        {
            using (DataAccess.Comment db = new DataAccess.Comment())
            {
                db.Create(comment);
            }
        }

        public static List<TbComment> RetrieveList(int messageId)
        {
            using (DataAccess.Comment db = new DataAccess.Comment())
            {
                return db.RetrieveList(messageId);
            }
        }
    }
}
