using System.Threading;
using System.Threading.Tasks;
using Application.CommandHandlers.Login;
using Application.Commands.Login;
using Application.Tests.CommandHandlers.Login.Fixture;
using Domain.Entities;
using Moq;
using Persistence.IRepository.User;
using Xunit;

namespace Application.Tests.CommandHandlers.Login
{
    public class LoginUserCommandHandlerTests
    {
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly LoginUserCommandHandlerFixture _fixture;
        private readonly LoginUserCommandHandler _handler;

        public LoginUserCommandHandlerTests()
        {
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _fixture = new LoginUserCommandHandlerFixture();
            _handler = new LoginUserCommandHandler(_userRepositoryReader.Object);
        }

        [Fact]
        public async Task DontLoginUserCommandHandlerWhenUserNameIsIncorrect()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUserByUserNameLogin(_fixture.UserLoginName)).Returns((Domain.Entities.User)null);

            //Act
            var result = await _handler.Handle(new LoginUserCommand(_fixture.UserLoginName, _fixture.Password), CancellationToken.None);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DontLoginUserCommandHandlerWhenPasswordIsIncorrect()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUserByUserNameLogin(_fixture.UserLoginName)).Returns(_fixture.UserPasswordError);

            //Act
            var result = await _handler.Handle(new LoginUserCommand(_fixture.UserLoginName, _fixture.Password), CancellationToken.None);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public async Task LoginUserCommandHandlerWhenSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUserByUserNameLogin(_fixture.UserLoginName)).Returns(_fixture.User);

            //Act
            var result = await _handler.Handle(new LoginUserCommand(_fixture.UserLoginName, _fixture.Password), CancellationToken.None);

            //Assert
            Assert.True(result);
        }
    }
}