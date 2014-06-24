using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public class Category
    {
        public static List<TbCategory> RetrieveList()
        {
            using (DataAccess.Category db = new DataAccess.Category())
            {
                return db.RetrieveList();
            }
        }
    }
}
