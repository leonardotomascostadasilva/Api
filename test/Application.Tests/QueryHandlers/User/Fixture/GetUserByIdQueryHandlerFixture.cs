using System;

namespace Application.Tests.QueryHandlers.User.Fixture
{
    public class GetUserByIdQueryHandlerFixture
    {
        public GetUserByIdQueryHandlerFixture()
        {
            UserId = $"{Guid.NewGuid()}";
            User = new Domain.Entities.User { Id = UserId };
        }

        public string UserId { get; }
        public Domain.Entities.User User { get; }
    }
}