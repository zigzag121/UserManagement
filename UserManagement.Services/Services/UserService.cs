using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Core.Utilities;
using UserManagement.Data.Entities;
using UserManagement.Data.Repositories;
using UserManagement.Services.Interfaces;

namespace UserManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public BoolOutcome<User> GetUserById(int id)
        {
            return _userRepository.GetUserByID(id);
        }

        public BoolOutcome<List<User>> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public BoolOutcome<User> UpdateUser(int id, User user)
        {
           user.UserID = id;
           user.DateLastUpdated = DateTime.Now;
           if(!string.IsNullOrEmpty(user.Password))
           {
                user.Password = PasswordHasher.HashPassword(user.Password);
           }

           return _userRepository.UpdateUser(user);
        }
    }
}
