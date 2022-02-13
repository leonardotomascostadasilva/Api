using MediatR;

namespace Application.Commands.User
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public DeleteUserCommand(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}