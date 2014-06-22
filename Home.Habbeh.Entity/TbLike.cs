using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbLike
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int Rank { get; set; }

        public static TbLike ToEntity(System.Data.IDataReader reader)
        {
            TbLike lik = null;
            lik = new TbLike();
            lik.Id = Convert.ToInt32(reader["Id"]);
            lik.UserId = Convert.ToInt32(reader["UserId"]);
            lik.MessageId = Convert.ToInt32(reader["MessageId"]);
            lik.Rank = Convert.ToInt32(reader["Rank"]);
            return lik;
        }
    }
}
