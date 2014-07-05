using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;
using System.Data;

namespace Home.Habbeh.DataAccess
{
    public class Message : IDisposable
    {
        private SqlConnection con;

        public Message()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Create(TbMessage msg)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbMessage (CategoryId,UserId,RegisterDate,SendDate,Description) values (@CategoryId,@UserId,@RegisterDate,@SendDate,@Description)";
            cmd.Parameters.AddWithValue("@CategoryId", msg.CategoryId);
            cmd.Parameters.AddWithValue("@UserId", msg.UserId);
            cmd.Parameters.AddWithValue("@RegisterDate", msg.RegisterDate);
            cmd.Parameters.AddWithValue("@SendDate", msg.SendDate);
            cmd.Parameters.AddWithValue("@Description", msg.Description);
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
            }
        }

        public List<TbMessage> RetrieveList(String lastUpdateMessage)
        {
            List<TbMessage> result = new List<TbMessage>();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = @"SELECT  * from ViewTbMessage where SendDate>@SendDate";

            cmd.Parameters.AddWithValue("@SendDate", lastUpdateMessage);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbMessage.ToEntity(reader));
            }
            return result;
        }

        public List<TbMessage> RetrieveUserMessageList(int userId)
        {
            List<TbMessage> result = new List<TbMessage>();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = @"SELECT  * from ViewTbMessage where UserId=@UserId";

            cmd.Parameters.AddWithValue("@UserId", userId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbMessage.ToEntity(reader));
            }
            return result;
        }


        public int CountNewMessage(string LastReadMessage)
        {
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = @"SELECT  count(*) as count FROM  TbMessage WHERE SendDate > @SendDate";

            cmd.Parameters.AddWithValue("@SendDate", LastReadMessage);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return Convert.ToInt32(reader["count"]);
            }
            return 0;
        }

        public TbMessage Retrieve(int messageId)
        {
            SqlCommand cmd = con.CreateCommand();
            
            cmd.CommandText = @"SELECT  * from ViewTbMessage where Id=@Id";

            cmd.Parameters.AddWithValue("@Id", messageId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return TbMessage.ToEntity(reader);
            }
            return null;
        }

        public void Update(TbMessage msg)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Update TbMessage set CategoryId=@CategoryId , Description=@Description,RegisterDate=@RegisterDate,SendDate=@SendDate,UserId=@UserId where Id=@Id";
            cmd.Parameters.AddWithValue("@CategoryId", msg.CategoryId);
            cmd.Parameters.AddWithValue("@Description", msg.Description);
            cmd.Parameters.AddWithValue("@RegisterDate", msg.RegisterDate);
            cmd.Parameters.AddWithValue("@SendDate", msg.SendDate);
            cmd.Parameters.AddWithValue("@UserId", msg.UserId);
            cmd.Parameters.AddWithValue("@Id", msg.Id);

            cmd.ExecuteNonQuery();
        }
    }
}
