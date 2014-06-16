using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;

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
            cmd.CommandText = "Insert Into TbMessage (CategoryId,UserId,RegisterDate,Description) values (@CategoryId,@UserId,@RegisterDate,@Descriptio)";
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
    }
}
