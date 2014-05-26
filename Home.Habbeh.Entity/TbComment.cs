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
        public int MessageId { get; set; }
        public DateTime RegisterDate { get; set; }
        public int CommentTypeCode { get; set; }
        public string Description { get; set; }
    }
}
