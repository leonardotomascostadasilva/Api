namespace Application.Tests.CommandHandlers.Login.Fixture
{
    public class LoginUserCommandHandlerFixture
    {
        public LoginUserCommandHandlerFixture()
        {
            Password = "1234";
            UserLoginName = "test";
            User = new Domain.Entities.User { Password = Password, UserNameLogin = UserLoginName };
            UserPasswordError = new Domain.Entities.User { Password = "test", UserNameLogin = "test" };
        }

        public string Password { get; }
        public string UserLoginName { get; }
        public Domain.Entities.User User { get; }
        public Domain.Entities.User UserPasswordError { get; }
    }
}