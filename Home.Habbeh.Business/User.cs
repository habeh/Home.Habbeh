using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class User
    {
        public static void Register(TbUser user)
        {
            using (DataAccess.User userData = new DataAccess.User())
            {
                Entity.TbUser newUser = new TbUser();
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                newUser.Password = user.Password;
                newUser.StatusId = 1;
                newUser.RegisterDate = DateTime.Now;
                /*TODO : Check Duplicate Email and UserName*/

                /*Create User*/
                userData.Create(newUser);
            }

            /*Send Verification Email*/
            SendEmail(user.Email, "Verification");
        }

        public static void SendForgiveInformation(string email)
        {
            SendEmail(email, "Forgive");
        }

        public static TbUser Login(string userName, string password)
        {
            using (DataAccess.User userData = new DataAccess.User())
            {
                TbUser user = userData.Retrieve(userName, password);
                
                /*clear password before send to client*/
                user.Password = null;

                return user;
            }
        }

        public static TbUser GetProfile(string username)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                return db.Retrieve(username);
            }
        }

        public static List<TbUser> Search(string searchText)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                return db.RetrieveList(searchText);
            }
        }

        public static void ChangeStatus(int userId, int statusCode, int changerUserId)
        {
            throw new NotImplementedException();
        }

        public static void Follow(int userId, int followerId)
        {
            throw new NotImplementedException();
        }

        private static void SendEmail(string email, string data)
        {
            //TODO: Email Service
        }

    }
}
