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
            cmd.CommandText = "Insert Into TbMessage (CategoryId,UserId,RegisterDate,Description) values (@CategoryId,@UserId,@RegisterDate,@Description)";
            cmd.Parameters.AddWithValue("@CategoryId", msg.CategoryId);
            cmd.Parameters.AddWithValue("@UserId", msg.UserId);
            cmd.Parameters.AddWithValue("@RegisterDate", msg.RegisterDate);
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

        public List<TbMessage> RetrieveList(DateTime lastReadMessage)
        {
            List<TbMessage> result = new List<TbMessage>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from TbMessage where SendDate > @SendDate";
            cmd.Parameters.AddWithValue("@SendDate", lastReadMessage);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbMessage.ToEntity(reader));
            }
            return result;
        }
    }
}
