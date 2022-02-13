using System.Collections.Generic;
using MediatR;

namespace Application.Queries.User
{
    public class GetUsersQuery : IRequest<List<Domain.Entities.User>>
    {
    }
}