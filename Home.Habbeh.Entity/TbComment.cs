using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbComment
    {
        /// <remarks></remarks>
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OffendingUserId { get; set; }
        public int MessageId { get; set; }
        public DateTime RegisterDate { get; set; }
        public int CommentTypeId { get; set; }
        public string Description { get; set; }

        public static TbComment ToEntity(System.Data.IDataReader reader)
        {
            TbComment comment = null;
            comment = new TbComment();
            comment.Id = Convert.ToInt32(reader["Id"]);
            if (reader["MessageId"] != DBNull.Value)
            comment.MessageId = Convert.ToInt32(reader["MessageId"]);
            comment.CommentTypeId = Convert.ToInt32(reader["CommentTypeId"]);
            comment.UserId = Convert.ToInt32(reader["UserId"]);
            if (reader["OffendingUserId"] != DBNull.Value)
            comment.OffendingUserId = Convert.ToInt32(reader["OffendingUserId"]);
            comment.Description = Convert.ToString(reader["Description"]);
            comment.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);

            return comment;
        }
    }
}
