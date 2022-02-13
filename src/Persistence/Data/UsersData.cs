using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Persistence.Data
{
    public static class UsersData
    {
        public static List<User> _users = new List<User>
        {
            new User
            {
                Document = "222222222",
                Email = "admin@admin",
                Id = $"{Guid.NewGuid()}",
                Name = "admin",
                Password = "12345",
                UserNameLogin = "admin"
            }
        };
    }
}