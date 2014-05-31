using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Location { get; set; }
        public byte[] Picture { get; set; }
        public DateTime RegisterDate { get; set; }
        public int StatusCode { get; set; }
        public string Password { get; set; }
    }
}
