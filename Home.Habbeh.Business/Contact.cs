using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Home.Habbeh.Entity;

namespace Home.Habbeh.Business
{
    public static class Contact
    {
        public static void Create(TbContact contact)
        {
            using (DataAccess.Contact db = new DataAccess.Contact())
            {
                contact.RegisterDate = DateTime.Now;
                contact.Status = 1;
                db.Create(contact);
            }
        }
    }
}
