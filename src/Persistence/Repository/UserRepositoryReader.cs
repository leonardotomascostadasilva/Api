using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.Data;
using Persistence.IRepository.User;

namespace Persistence.Repository
{
    public class UserRepositoryReader : IUserRepositoryReader
    {
        private List<User> users;

        public UserRepositoryReader()
        {
            users = UsersData._users;
        }
        
        public List<User> GetUsers()
        {
            return users;
        }

        public User GetUserById(string userId)
        {
            return users.FirstOrDefault(user => user.Id == userId);
        }

        public User GetUserByUserNameLogin(string userNameLogin)
        {
            return users.FirstOrDefault(user => user.UserNameLogin == userNameLogin);
        }
    }
}