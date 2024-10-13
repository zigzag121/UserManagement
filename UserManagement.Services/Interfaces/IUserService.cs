using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Utilities;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        BoolOutcome<List<User>> GetUsers();
        BoolOutcome<User> GetUserById(int id);
        BoolOutcome<User> UpdateUser(int id, User user);
    }
}
