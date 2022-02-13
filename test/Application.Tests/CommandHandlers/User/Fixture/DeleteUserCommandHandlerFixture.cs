using System;
using System.Collections.Generic;

namespace Application.Tests.CommandHandlers.User.Fixture
{
    public class DeleteUserCommandHandlerFixture
    {
        public DeleteUserCommandHandlerFixture()
        {
            UserId = $"{Guid.NewGuid()}";
            User = new Domain.Entities.User { Id = UserId };

            UserNotFound = new Domain.Entities.User { Id = $"{Guid.NewGuid()}" };

            Users = new List<Domain.Entities.User>
            {
                new Domain.Entities.User { Id = UserId }
            };
        }

        public string UserId { get; }
        public Domain.Entities.User User { get; }
        public Domain.Entities.User UserNotFound { get; }
        public List<Domain.Entities.User> Users { get; }
    }
}