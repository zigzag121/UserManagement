using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Utilities;
using UserManagement.Data.Entities;

namespace UserManagement.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public BoolOutcome<User> GetUserByID(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserID == id);
            if (user == null) 
            {
                return new BoolOutcome<User>(true, "User found.", user);
            }
            else 
            {
                return new BoolOutcome<User>(false, "User not found.");
            }
        }

        public BoolOutcome<List<User>> GetUsers()
        {
            var users = _context.Users.ToList();
            if (users.Any()) 
            {
                return new BoolOutcome<List<User>>(true, "Users retrieved successfully.", users);
            }
            else
            {
                return new BoolOutcome<List<User>>(false, "No users found.");
            }
        }

        public BoolOutcome<User> UpdateUser(User user)
        {
            var getUserResult = GetUserByID(user.UserID);
            if(getUserResult.Success == false) {return getUserResult; }

            var existingUser = getUserResult.Data;
            existingUser.UserID = user.UserID;
            existingUser.UserType = user.UserType;
            existingUser.UserEmail = user.UserEmail;
            existingUser.Password = user.Password;
            existingUser.DateLastUpdated = DateTime.Now;
            try
            {
                _context.SaveChanges();
                return new BoolOutcome<User>(true, "User updated successfully.", existingUser);
            }
            catch (Exception ex) 
            {
                return new BoolOutcome<User>(false, "An error occured while updating the user.");
            }

        }

    }
}
