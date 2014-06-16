using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class Like
    {
        public static void Create(TbLike like)
        {
            using (DataAccess.Like db = new DataAccess.Like())
            {
                db.Create(like);
            }
        }
    }
}
