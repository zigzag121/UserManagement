using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Data.Entities
{
    public class UserTransport
    {
        public int UserID { get; set; }
        public UserType UserType { get; set; }
        public string UserEmail { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }
}
