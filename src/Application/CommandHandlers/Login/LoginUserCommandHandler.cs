using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Login;
using MediatR;
using Persistence.IRepository.User;
using Serilog;

namespace Application.CommandHandlers.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;

        public LoginUserCommandHandler(IUserRepositoryReader userRepositoryReader)
        {
            _userRepositoryReader = userRepositoryReader;
        }

        public Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepositoryReader.GetUserByUserNameLogin(request.UserLoginName);

            if (user is null)
            {
                Log.Logger.Information("Your login username is incorrect.");
                return Task.FromResult(false);
            }

            if (user.Password != request.Password)
            {
                Log.Logger.Information("Your password is incorrect.");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}