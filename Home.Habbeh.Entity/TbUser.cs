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
        public string Picture { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }

        public static TbUser ToEntity(System.Data.IDataReader reader)
        {
            TbUser user = null;
            user = new TbUser();
            user.Id = Convert.ToInt32(reader["Id"]);
            user.UserName = reader["UserName"].ToString();
            if (reader["FirstName"] != DBNull.Value)
                user.FirstName = reader["FirstName"].ToString();
            if (reader["LastName"] != DBNull.Value)
                user.LastName = reader["LastName"].ToString();
            user.Email = reader["Email"].ToString();
            if (reader["PhoneNo"] != DBNull.Value)
                user.PhoneNo = reader["PhoneNo"].ToString();
            if (reader["Location"] != DBNull.Value)
                user.Location = reader["Location"].ToString();
            if (reader["Picture"] != DBNull.Value)
                user.Picture = reader["Picture"].ToString();

            if (reader["Status"] != DBNull.Value)
                user.Status = reader["Status"].ToString();
            user.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
            
            user.Password = reader["Password"].ToString();
            return user;
        }
    }
}
