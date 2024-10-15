using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Data.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public UserType UserType { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public static UserTransport ToUserTransport(User user)
        {
            return new UserTransport()
            {
                UserID = user.UserID,
                UserEmail = user.UserEmail,
                UserType = user.UserType,
                DateLastUpdated = user.DateLastUpdated,
                DateJoined = user.DateJoined,
            };
        }
    }
}
