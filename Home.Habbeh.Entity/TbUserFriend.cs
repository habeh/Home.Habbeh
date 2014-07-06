using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Habbeh.Entity
{
    public class TbUserFriend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public String UserName { get; set; }
        public int FriendId { get; set; }
        public String FriendUserName { get; set; }
        public String Accept { get; set; }
        
        



        public static TbUserFriend ToEntity(System.Data.IDataReader reader)
        {
            TbUserFriend userfriend = null;
            userfriend = new TbUserFriend();
            userfriend.Id = Convert.ToInt32(reader["Id"]);
            userfriend.UserId = Convert.ToInt32(reader["UserId"]);
            userfriend.UserName = reader["UserName"].ToString();
            userfriend.FriendId = Convert.ToInt32(reader["FriendId"]);
            userfriend.FriendUserName = reader["FriendUserName"].ToString();
            userfriend.Accept = reader["Accept"].ToString();
            
            

            return userfriend;
        }
    }
}
