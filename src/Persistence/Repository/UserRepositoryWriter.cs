using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Persistence.Data;
using Persistence.IRepository.User;

namespace Persistence.Repository
{
    public class UserRepositoryWriter : IUserRepositoryWriter
    {
        private List<User> users;

        public UserRepositoryWriter()
        {
            users = UsersData._users;
        }

        public User CreateUser(User user)
        {
            users.Add(user);
            return user;
        }

        public User UpdateUser(User userRequest)
        {
            return userRequest;
        }

        public void DeleteUser(string userId)
        {
            var user = users.First(u => u.Id == userId);

            users.Remove(user);
        }
    }
}