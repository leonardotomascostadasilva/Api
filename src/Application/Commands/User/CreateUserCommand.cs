using MediatR;

namespace Application.Commands.User
{
    public class CreateUserCommand : IRequest<Domain.Entities.User>
    {
        public CreateUserCommand(Domain.Entities.User user)
        {
            User = user;
        }
        public Domain.Entities.User User { get; set; }
    }
}