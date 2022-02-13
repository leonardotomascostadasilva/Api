using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.User;
using MediatR;
using Persistence.IRepository.User;

namespace Application.QueryHandlers.User
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<Domain.Entities.User>>
    {
        private readonly IUserRepositoryReader _userRepositoryReader;

        public GetUsersQueryHandler(IUserRepositoryReader userRepositoryReader)
        {
            _userRepositoryReader = userRepositoryReader;
        }

        public Task<List<Domain.Entities.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userRepositoryReader.GetUsers());
        }
    }
}