using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Home.Habbeh.Entity;

namespace Home.Habbeh.DataAccess
{
    public class Category : IDisposable
    {
        private SqlConnection con;

        public Category()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Dispose()
        {
            if (con != null)
            {
                con.Dispose();
            }
        }

        public List<TbCategory> RetrieveList()
        {
            List<TbCategory> result = new List<TbCategory>();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = @"SELECT * from TbCategory";
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbCategory.ToEntity(reader));
            }
            return result;
        }
    }
}
