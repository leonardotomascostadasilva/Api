using Api.Models.Request.Login;

namespace Api.Tests.Controllers.v1.Fixture
{
    public class LoginControllerFixture
    {
        public LoginControllerFixture()
        {
            UserLoginName = "test";
            Password = "test";
            LoginRequest = new LoginRequest { UserLoginName = UserLoginName, Password = Password };
        }

        public string UserLoginName { get; }
        public string Password { get; }
        public LoginRequest LoginRequest { get; set; }
    }
}