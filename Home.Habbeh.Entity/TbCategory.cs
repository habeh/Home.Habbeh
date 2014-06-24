using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public static TbCategory ToEntity(System.Data.IDataReader reader)
        {
            TbCategory cat = null;
            cat = new TbCategory();
            cat.Id = Convert.ToInt32(reader["Id"]);
            cat.Title = Convert.ToString(reader["Title"]);

            return cat;
        }
    }
}
