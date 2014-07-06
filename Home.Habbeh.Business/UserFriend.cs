using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;
using Home.Habbeh.Entity.Common;
using System.Net.Mail;
using System.Net;

namespace Home.Habbeh.Business
{
    public static class UserFriend
    {
        public static void Create(int userId,int friendId)
        {
            using (DataAccess.UserFriend db = new DataAccess.UserFriend())
            {
                
                db.Create(userId,friendId);
            }
        }

        public static void Accept(int id)
        {
            using (DataAccess.UserFriend db = new DataAccess.UserFriend())
            {

                db.Update(id);
            }
        }

        public static List<TbUserFriend> Search(int userId)
        {
            using (DataAccess.UserFriend db = new DataAccess.UserFriend())
            {
                return db.RetrieveList(userId);
            }
        }

       


        public static String CheckFriend(int userId, int friendId)
        {
            using (DataAccess.UserFriend db = new DataAccess.UserFriend())
            {
                String user = db.Check(userId, friendId);
 

                return user;
               
            }
        }
    }
}
