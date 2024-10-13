using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Utilities;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Repositories
{
    public interface IUserRepository
    {
        BoolOutcome<List<User>> GetUsers();
        BoolOutcome<User> GetUserByID(int id);
        BoolOutcome<User> UpdateUser(User user);
    }
}
