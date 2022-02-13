using MediatR;

namespace Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<Domain.Entities.User>
    {
        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}