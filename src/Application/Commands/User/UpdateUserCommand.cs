using MediatR;

namespace Application.Commands.User
{
    public class UpdateUserCommand : IRequest<Domain.Entities.User>
    {
        public UpdateUserCommand(string userId, Domain.Entities.User user)
        {
            UserId = userId;
            User = user;
        }
        
        public string UserId { get; set; }
        public Domain.Entities.User User { get; set; }
    }
}