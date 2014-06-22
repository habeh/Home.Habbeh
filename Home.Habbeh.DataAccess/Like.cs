using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;
using System.Data;

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

        public TbLike Retrieve(int messageId, int userId)
        {
            TbLike result = null;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from TbLike where userId=@UserId and messageId=@MessageId";
            cmd.Parameters.AddWithValue("@MessageId", messageId);
            cmd.Parameters.AddWithValue("@UserId", userId);

            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    result = TbLike.ToEntity(reader);
            }
            return result;
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
            }
        }

        public int RetrieveCount(int messageId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(Id) AS CountLike FROM  TbLike where MessageId = @MessageId";
            cmd.Parameters.AddWithValue("@MessageId", messageId);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return Convert.ToInt32(reader["CountLike"]);
            }
            return 0;
        }
    }
}
