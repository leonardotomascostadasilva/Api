using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.User;
using MediatR;
using Persistence.IRepository.User;
using Serilog;

namespace Application.CommandHandlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Domain.Entities.User>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;
        private readonly IUserRepositoryWriter _userRepositoryWriter;

        public CreateUserCommandHandler(IUserRepositoryReader userRepositoryReader, IUserRepositoryWriter userRepositoryWriter)
        {
            _userRepositoryReader = userRepositoryReader;
            _userRepositoryWriter = userRepositoryWriter;
        }

        public Task<Domain.Entities.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var users = _userRepositoryReader.GetUsers();

            if (users.Any(u => u.Document == request.User.Document))
            {
                Log.Logger.Information("There is already a user with this document.");
                return Task.FromResult<Domain.Entities.User>(null);
            }

            request.User.Id = $"{Guid.NewGuid()}";

            return Task.FromResult(_userRepositoryWriter.CreateUser(request.User));
        }
    }
}