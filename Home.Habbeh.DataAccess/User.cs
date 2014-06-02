using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;
using System.Data.SqlClient;

namespace Home.Habbeh.DataAccess
{
    public class User : IDisposable
    {
        private SqlConnection con;

        public User()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }
        public void Create(TbUser user)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbUser (UserName,Email,Password,StatusId,RegisterDate) values (@UserName,@Email,@Password,@StatusId,@RegisterDate)";
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@StatusId", user.StatusId);
            cmd.Parameters.AddWithValue("@RegisterDate", user.RegisterDate);
            cmd.ExecuteNonQuery();
        }

        public void SendForgiveInformation(string email)
        {

        }

        public TbUser Login(string username, string password)
        {
            return new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 };
        }

        public TbUser GetProfile(int userId)
        {
            return new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 };
        }

        public List<TbUser> Search(string searchText)
        {
            return new List<TbUser>() { 
                new TbUser() { Email = "RoomezOnline@yahoo.com", UserName = "roomezonline", StatusId = 1 },
                new TbUser() { Email = "karim_medusa@yahoo.com", UserName = "karim_medusa", StatusId = 1 }};
        }

        public void ChangeStatus(int userId, int statusCode, int changerUserId)
        {

        }

        public void Follow(int userId, int followerId)
        {

        }

        public void Dispose()
        {
            if (con != null)
            {                
                con.Dispose();
            }
        }
    }
}
