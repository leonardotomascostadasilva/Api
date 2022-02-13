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
    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly Mock<IUserRepositoryWriter> _userRepositoryWriter;
        private readonly UpdateUserCommandHandler _handler;
        private readonly UpdateUserCommandHandlerFixture _fixture;

        public UpdateUserCommandHandlerTests()
        {
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _userRepositoryWriter = new Mock<IUserRepositoryWriter>();
            _fixture = new UpdateUserCommandHandlerFixture();
            _handler = new UpdateUserCommandHandler(_userRepositoryReader.Object, _userRepositoryWriter.Object);
        }

        [Fact]
        public async Task DontUpdateUserCommandHandlerWhenUserNotFound()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);

            //Act
            var result = await _handler.Handle(new UpdateUserCommand(_fixture.UserNotFound.Id, _fixture.UserNotFound), CancellationToken.None);

            //Assert
            Assert.Null(result);
            _userRepositoryWriter.Verify(e => e.UpdateUser(It.IsAny<Domain.Entities.User>()), Times.Never);
        }

        [Fact]
        public async Task UpdateUserCommandHandlerWhenSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);
            _userRepositoryWriter.Setup(e => e.UpdateUser(It.Is<Domain.Entities.User>(u => u.Id == _fixture.User.Id))).Returns(_fixture.User);

            //Act
            var result = await _handler.Handle(new UpdateUserCommand(_fixture.UserId, _fixture.User), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            _userRepositoryWriter.Verify(e => e.UpdateUser(It.Is<Domain.Entities.User>(u => u.Id == _fixture.User.Id)), Times.Exactly(1));
        }
    }
}