using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbMessage
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime SendDate { get; set; }
        public string Description { get; set; }
    }
}
