using System.Threading;
using System.Threading.Tasks;
using Application.Queries.User;
using MediatR;
using Persistence.IRepository.User;
using Serilog;

namespace Application.QueryHandlers.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.User>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;

        public GetUserByIdQueryHandler(IUserRepositoryReader userRepositoryReader)
        {
            _userRepositoryReader = userRepositoryReader;
        }

        public Task<Domain.Entities.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepositoryReader.GetUserById(request.UserId);

            if (user is null)
            {
                Log.Logger.Information("User not found.");
                return Task.FromResult<Domain.Entities.User>(null);
            }
            
            return Task.FromResult(user);
        }
    }
}