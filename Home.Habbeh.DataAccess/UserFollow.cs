using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;

namespace Home.Habbeh.DataAccess
{
    public class UserFollow:IDisposable
    {
        private SqlConnection con;

        public UserFollow()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Create(int userId, int followerId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbUserFollow (UserId,FollowerId) values (@UserId,@FollowerId)";
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@FollowerId", followerId);
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
