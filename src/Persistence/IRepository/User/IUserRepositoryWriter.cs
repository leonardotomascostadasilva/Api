
namespace Persistence.IRepository.User
{
    public interface IUserRepositoryWriter
    {
        Domain.Entities.User CreateUser(Domain.Entities.User user);
        Domain.Entities.User UpdateUser(Domain.Entities.User userRequest);
        void DeleteUser(string userId);
    }
}