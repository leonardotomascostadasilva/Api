using MediatR;

namespace Application.Commands.Login
{
    public class LoginUserCommand : IRequest<bool>
    {
        public LoginUserCommand(string userLoginName, string password)
        {
            UserLoginName = userLoginName;
            Password = password;
        }
        
        public string UserLoginName { get; set; }
        public string Password { get; set; }
    }
}