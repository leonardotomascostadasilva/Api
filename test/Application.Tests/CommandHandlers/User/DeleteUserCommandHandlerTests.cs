using System.Threading;
using System.Threading.Tasks;
using Application.CommandHandlers.User;
using Application.Commands.User;
using Application.Tests.CommandHandlers.User.Fixture;
using Moq;
using Persistence.IRepository.User;
using Xunit;

namespace Application.Tests.CommandHandlers.User
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly Mock<IUserRepositoryWriter> _userRepositoryWriter;
        private readonly DeleteUserCommandHandler _handler;
        private readonly DeleteUserCommandHandlerFixture _fixture;

        public DeleteUserCommandHandlerTests()
        {
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _userRepositoryWriter = new Mock<IUserRepositoryWriter>();
            _fixture = new DeleteUserCommandHandlerFixture();
            _handler = new DeleteUserCommandHandler(_userRepositoryReader.Object, _userRepositoryWriter.Object);
        }

        [Fact]
        public async Task DontDeleteUserCommandHandlerWhenUserNotFound()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);

            //Act
            var result = await _handler.Handle(new DeleteUserCommand(_fixture.UserNotFound.Id), CancellationToken.None);

            //Assert
            Assert.False(result);
            _userRepositoryWriter.Verify(e => e.DeleteUser(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task DeleteUserCommandHandlerWhenSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);

            //Act
            var result = await _handler.Handle(new DeleteUserCommand(_fixture.UserId), CancellationToken.None);

            //Assert
            Assert.True(result);
            _userRepositoryWriter.Verify(e => e.DeleteUser(_fixture.UserId), Times.Exactly(1));
        }
    }
}