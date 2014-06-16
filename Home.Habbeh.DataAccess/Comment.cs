using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Home.Habbeh.Entity;
using System.Data;

namespace Home.Habbeh.DataAccess
{
    public class Comment : IDisposable
    {
        private SqlConnection con;

        public Comment()
        {
            con = new SqlConnection(Utility.ConnectionString);
            con.Open();
        }

        public void Create(TbComment comment)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Insert Into TbComment (CommentTypeId,UserId,MessageId,Description,RegisterDate) values (@CommentTypeId,@UserId,@MessageId,@Description,@RegisterDate)";
            cmd.Parameters.AddWithValue("@MessageId", comment.MessageId);
            cmd.Parameters.AddWithValue("@UserId", comment.UserId);
            cmd.Parameters.AddWithValue("@CommentTypeId", comment.CommentTypeId);
            cmd.Parameters.AddWithValue("@Description", comment.Description);
            cmd.Parameters.AddWithValue("@RegisterDate", comment.RegisterDate);
            cmd.ExecuteNonQuery();
        }

        public List<TbComment> RetrieveList(int messageId)
        {
            List<TbComment> result = new List<TbComment>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from TbComment where MessageId = @MessageId";
            cmd.Parameters.AddWithValue("@MessageId", messageId);
            using (IDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(TbComment.ToEntity(reader));
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
    }
}
