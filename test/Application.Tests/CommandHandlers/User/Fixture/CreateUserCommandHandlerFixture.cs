using System.Collections.Generic;

namespace Application.Tests.CommandHandlers.User.Fixture
{
    public class CreateUserCommandHandlerFixture
    {
        public CreateUserCommandHandlerFixture()
        {
            User = new Domain.Entities.User { Document = "544332" };

            UserDocumentAlreadyExists = new Domain.Entities.User { Document = "12345" };

            Users = new List<Domain.Entities.User>
            {
                new Domain.Entities.User { Document = "12345" }
            };
        }

        public Domain.Entities.User User { get; }
        public Domain.Entities.User UserDocumentAlreadyExists { get; }
        public List<Domain.Entities.User> Users { get; }
    }
}