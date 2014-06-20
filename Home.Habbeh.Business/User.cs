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
                newUser.Status = "I am Online In Habbeh";
                newUser.RegisterDate = DateTime.Now;

                /*Check Required Fields UserName,Email,Password*/
                if (string.IsNullOrEmpty(user.UserName)) { throw new HabbeException("نام کاربری اجباری است"); }
                if (string.IsNullOrEmpty(user.Email)) { throw new HabbeException("ایمیل اجباری است"); }
                if (string.IsNullOrEmpty(user.Password)) { throw new HabbeException("رمز عبور اجباری است"); }

                /*Check Duplicate UserName*/
                if (userData.Retrieve(user.UserName) != null)
                {
                    throw new HabbeException("نام کاربری تکراری است");
                }

                /*Check Duplicate Email */
                if (userData.RetrieveByEmail(user.Email) != null)
                {
                    throw new HabbeException("ایمیل تکراری است");
                }

                /*Create User*/
                userData.Create(newUser);
            }

            /*Send Verification Email*/
            SendEmail(user.Email, EmailType.Verification);
        }

        public static void SendForgiveInformation(string email)
        {
            SendEmail(email, EmailType.Forgive);
        }

        public static TbUser Login(string userName, string password)
        {
            using (DataAccess.User userData = new DataAccess.User())
            {
                TbUser user = userData.Retrieve(userName, password);

                /*clear password before send to client*/
                if (user != null)
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

        public static void SaveProfile(TbUser user)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                db.Update(user);
            }
        }

        public static List<TbUser> Search(string searchText)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                return db.RetrieveList(searchText);
            }
        }

        public static void ChangeStatus(string userName, int statusId)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                db.Update(userName, statusId);
            }
        }

        public static void Follow(string userName, string followerUserName)
        {
            using (DataAccess.User db = new DataAccess.User())
            {
                TbUser user = db.Retrieve(userName);

                TbUser follower = db.Retrieve(followerUserName);

                if (user != null && follower != null)
                {
                    using (DataAccess.UserFollow ufDb = new DataAccess.UserFollow())
                    {
                        ufDb.Create(user.Id, follower.Id);
                    }
                }
            }
        }

        private static void SendEmail(string email, EmailType emailType)
        {
            //TODO: Email Service, background Thread for send email 

            /*TODO : Create some recored in database*/

            switch (emailType)
            {
                case EmailType.Forgive:
                    SendEmail("ارسال ایمیل یاداوری", email, "ایمیل یاداوری");
                    break;
                case EmailType.Verification:
                    SendEmail("ارسال ایمیل تایید ثبت نام", email, "ایمیل تایید ثبت نام");
                    break;
            }
        }

        private static void SendEmail(string body, string email, string subject)
        {
            using (MailMessage mm = new MailMessage())
            {
                MailAddress fromAddress = new MailAddress("habbeh.info@gmail.com");
                mm.From = fromAddress;
                mm.To.Add(email);
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential("habbeh.info@gmail.com", "habbeh_android");
                smtp.Credentials = NetworkCred;
                smtp.Port = 587; //465
                smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                smtp.SendAsync(mm, "token");
            }
        }

        private static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //TODO : delete some records from Database

        }

    }
}
