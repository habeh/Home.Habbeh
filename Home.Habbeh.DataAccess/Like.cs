using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;

namespace Home.Habbeh.DataAccess
{
    public class Like : IDisposable
    {
        private SqlConnection con;

        public Like()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Create(TbLike like)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbLike (UserId,MessageId,Rank) values (@UserId,@MessageId,@Rank)";
            cmd.Parameters.AddWithValue("@MessageId", like.MessageId);
            cmd.Parameters.AddWithValue("@UserId", like.UserId);
            cmd.Parameters.AddWithValue("@Rank", like.Rank);  
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
