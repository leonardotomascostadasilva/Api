using System.Collections.Generic;

namespace Persistence.IRepository.User
{
    public interface IUserRepositoryReader
    {
        List<Domain.Entities.User> GetUsers();
        Domain.Entities.User GetUserById(string userId);
        Domain.Entities.User GetUserByUserNameLogin(string userNameLogin);
    }
}