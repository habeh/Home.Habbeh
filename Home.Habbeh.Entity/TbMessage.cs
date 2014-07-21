using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Home.Habbeh.Entity
{
    [DataContract]
    public class TbMessage
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public String CategoryTitle { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public DateTime RegisterDate { get; set; }

        [DataMember]
        public DateTime SendDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Share { get; set; }

        public static TbMessage ToEntity(System.Data.IDataReader reader)
        {
            TbMessage msg = null;
            msg = new TbMessage();
            msg.Id = Convert.ToInt32(reader["Id"]);
            msg.CategoryId = Convert.ToInt32(reader["CategoryId"]);
            msg.UserId = Convert.ToInt32(reader["UserId"]);
            msg.Description = Convert.ToString(reader["Description"]);
            msg.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
            if (reader["SendDate"] != DBNull.Value)
                msg.SendDate = Convert.ToDateTime(reader["SendDate"]);
            msg.CategoryTitle = Convert.ToString(reader["CategoryTitle"]);
            if (reader["Share"] != DBNull.Value)
                msg.Share = Convert.ToInt32(reader["Share"]);
            return msg;
        }
    }
}
