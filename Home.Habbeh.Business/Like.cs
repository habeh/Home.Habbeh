using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class Like
    {
        public static bool Create(TbLike like)
        {
            using (DataAccess.Like db = new DataAccess.Like())
            {
                TbLike duplike = db.Retrieve(like.MessageId, like.UserId);
                if (duplike == null)
                {
                    db.Create(like);
                    return true;
                }
                else
                {
                    db.Delete(like);
                    return false;
                }
            }
        }

        public static int CountLike(int messageId)
        {
            using (DataAccess.Like db = new DataAccess.Like())
            {
                return db.RetrieveCount(messageId);
            }
        }

    }
}
