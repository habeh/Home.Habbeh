using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;
using System.Data.SqlClient;
using System.Data;

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
            cmd.CommandText = "Insert Into TbUser (UserName,Email,Password,Status,RegisterDate) values (@UserName,@Email,@Password,@Status,@RegisterDate)";
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Status", user.Status);
            cmd.Parameters.AddWithValue("@RegisterDate", user.RegisterDate);
            cmd.ExecuteNonQuery();
        }

        public TbUser Retrieve(string userName, string password)
        {
            TbUser user = Retrieve(userName);
            if (user!=null && user.Password == password)
                return user;

            return null;
        }

        public TbUser Retrieve(string username)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from TbUser where UserName = @UserName";
            cmd.Parameters.AddWithValue("@UserName", username);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return TbUser.ToEntity(reader);
            }
            return null;
        }

        public TbUser RetrieveByEmail(string email)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from TbUser where Email= @Email";
            cmd.Parameters.AddWithValue("@Email", email);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return TbUser.ToEntity(reader);
            }
            return null;
        }

        public List<TbUser> RetrieveList(string searchText)
        {
            List<TbUser> result = new List<TbUser>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from TbUser where UserName like @UserName";
            cmd.Parameters.AddWithValue("@UserName", string.Format("%{0}%",searchText));
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbUser.ToEntity(reader));
            }
            return result;
        }

        public void Update(string userName, int statusId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update TbUser set StatusId=@StatusId where UserName=@UserName";
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@StatusId", statusId);
            cmd.ExecuteNonQuery();
        }

        public void Update(TbUser user)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update TbUser set FirstName=@FirstName , LastName=@LastName,Status=@Status,Password=@Password,Email=@Email where UserName=@UserName";
            cmd.Parameters.AddWithValue("@UserName", user.UserName);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Status", user.Status);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            cmd.ExecuteNonQuery();
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
