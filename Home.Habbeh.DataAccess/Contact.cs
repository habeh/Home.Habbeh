using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;

namespace Home.Habbeh.DataAccess
{
    public class Contact : IDisposable
    {
        private SqlConnection con;

        public Contact()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Create(TbContact contact)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbContact (UserId,Description,RegisterDate,Status) values (@UserId,@Description,@RegisterDate,@Status)";
            cmd.Parameters.AddWithValue("@Description", contact.Description);
            cmd.Parameters.AddWithValue("@UserId", contact.UserId);
            cmd.Parameters.AddWithValue("@RegisterDate", contact.RegisterDate);
            cmd.Parameters.AddWithValue("@Status", contact.Status);
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
