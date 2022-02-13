using System;
using System.Collections.Generic;
using Api.Models.Request.User;
using Domain.Entities;

namespace Api.Tests.Controllers.v1.Fixture
{
    public class UserControllerFixture
    {
        public UserControllerFixture()
        {
            UserId = $"{Guid.NewGuid()}";
            User = new User
            {
                Document = "1234",
                Email = "test@test",
                Id = UserId,
                Name = "test",
                Password = "test",
                UserNameLogin = "test"
            };
            CreateUserRequest = new CreateUserRequest
            {
                Document = "1234",
                Email = "test@test",
                Name = "test",
                Password = "test",
                UserNameLogin = "test"
            };

            UpdateUserRequest = new UpdateUserRequest
            {
                UserNameLogin = "test",
                Email = "test@test",
                Name = "test",
            };
            Users = new List<User>
            {
                new User
                {
                    Document = "1234",
                    Email = "test@test",
                    Id = UserId,
                    Name = "test",
                    Password = "test",
                    UserNameLogin = "test"
                }
            };
        }

        public string UserId { get; }
        public User User { get; }
        public CreateUserRequest CreateUserRequest { get; }
        public UpdateUserRequest UpdateUserRequest { get; }
        public List<User> Users { get; set; }
    }
}