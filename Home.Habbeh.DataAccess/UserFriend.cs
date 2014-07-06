using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;
using System.Data.SqlClient;
using System.Data;

namespace Home.Habbeh.DataAccess
{
    public class UserFriend : IDisposable
    {
         private SqlConnection con;

        public UserFriend()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }
        public void Create(int userId, int friendId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbUserFriend(UserId,FriendId) values (@UserId,@FriendId)";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@FriendId", friendId);
            cmd.ExecuteNonQuery();
        }


        public void Update(int id)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update TbUserFriend set Accept=@Accept where Id=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Accept", "true");
            cmd.ExecuteNonQuery();
        }

        public List<TbUserFriend> RetrieveList(int userId)
        {
            List<TbUserFriend> result = new List<TbUserFriend>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from ViewUserFriend where UserId=@Userid";
            cmd.Parameters.AddWithValue("@UserId",userId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbUserFriend.ToEntity(reader));
            }
            return result;
        }

        public  String Check(int userId,int friendId)
        {
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select * from TbUserFriend where UserId=@UserId And FriendId=@FriendId";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@FriendId", friendId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return "true";
                }
                else
                {
                    return "false";
                }
            }
            return null;
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
