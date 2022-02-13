using System.Collections.Generic;

namespace Application.Tests.QueryHandlers.User.Fixture
{
    public class GetUsersQueryHandlerFixture
    {
        public GetUsersQueryHandlerFixture()
        {
            Users = new List<Domain.Entities.User>();
        }
        public List<Domain.Entities.User> Users { get; }
    }
}