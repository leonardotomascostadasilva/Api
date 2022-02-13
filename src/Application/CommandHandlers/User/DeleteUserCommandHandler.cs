using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.User;
using MediatR;
using Persistence.IRepository.User;
using Serilog;

namespace Application.CommandHandlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;
        private readonly IUserRepositoryWriter _userRepositoryWriter;

        public DeleteUserCommandHandler(IUserRepositoryReader userRepositoryReader, IUserRepositoryWriter userRepositoryWriter)
        {
            _userRepositoryReader = userRepositoryReader;
            _userRepositoryWriter = userRepositoryWriter;
        }

        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var users = _userRepositoryReader.GetUsers();

            if (!users.Any(u => u.Id == request.UserId))
            {
                Log.Logger.Information("User not found.");
                return Task.FromResult(false);
            }

            var user = users.First(u => u.Id == request.UserId);

            _userRepositoryWriter.DeleteUser(user.Id);

            return Task.FromResult(true);
        }
    }
}