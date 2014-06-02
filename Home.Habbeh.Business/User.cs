using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class User
    {
        public static void Register(string username, string email, string password)
        {
            using (DataAccess.User userData = new DataAccess.User())
            {
                Entity.TbUser user = new TbUser();
                user.UserName = username;
                user.Email = email;
                user.Password = password;
                user.StatusId = 1;
                user.RegisterDate = DateTime.Now;
                /*TODO : Check Duplicate Email and UserName*/

                /*Create User*/
                userData.Create(user);
            }

            /*Send Verification Email*/
            SendEmail(email, "Verification");
        }

        public static void SendForgiveInformation(string email)
        {
            SendEmail(email, "Forgive");
        }

        public static TbUser Login(string username, string password)
        {
            return new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 };
        }

        public static TbUser GetProfile(int userId)
        {
            return new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 };
        }

        public static List<TbUser> Search(string searchText)
        {
            return new List<TbUser>() { 
                new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 },
                new TbUser() { Email = "karim_medusa@yahoo.com", UserName = "karim_medusa", StatusId = 1 }};
        }

        public static void ChangeStatus(int userId, int statusCode, int changerUserId)
        {

        }

        public static void Follow(int userId, int followerId)
        {

        }

        private static void SendEmail(string email, string data)
        {

        }

    }
}
