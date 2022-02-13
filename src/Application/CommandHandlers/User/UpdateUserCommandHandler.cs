using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.User;
using MediatR;
using Persistence.IRepository.User;
using Serilog;

namespace Application.CommandHandlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;
        private readonly IUserRepositoryWriter _userRepositoryWriter;

        public UpdateUserCommandHandler(IUserRepositoryReader userRepositoryReader, IUserRepositoryWriter userRepositoryWriter)
        {
            _userRepositoryReader = userRepositoryReader;
            _userRepositoryWriter = userRepositoryWriter;
        }

        public Task<Domain.Entities.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var users = _userRepositoryReader.GetUsers();

            if (!users.Any(u => u.Id == request.UserId))
            {
                Log.Logger.Information("User not found.");
                return Task.FromResult<Domain.Entities.User>(null);
            }

            var user = users.First(u => u.Id == request.UserId);

            user.Name = request.User.Name;
            user.Email = request.User.Email;
            user.UserNameLogin = request.User.UserNameLogin;

            return Task.FromResult(_userRepositoryWriter.UpdateUser(user));
        }
    }
}