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
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly Mock<IUserRepositoryWriter> _userRepositoryWriter;
        private readonly CreateUserCommandHandler _handler;
        private readonly CreateUserCommandHandlerFixture _fixture;

        public CreateUserCommandHandlerTests()
        {
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _userRepositoryWriter = new Mock<IUserRepositoryWriter>();
            _fixture = new CreateUserCommandHandlerFixture();
            _handler = new CreateUserCommandHandler(_userRepositoryReader.Object, _userRepositoryWriter.Object);
        }

        [Fact]
        public async Task DontCreateUserCommandHandlerWhenDocumentAlreadyExists()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);

            //Act
            var result = await _handler.Handle(new CreateUserCommand(_fixture.UserDocumentAlreadyExists), CancellationToken.None);

            //Assert
            Assert.Null(result);
            _userRepositoryWriter.Verify(e => e.CreateUser(It.IsAny<Domain.Entities.User>()), Times.Never);
        }

        [Fact]
        public async Task CreateUserCommandHandlerWhenSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);
            _userRepositoryWriter.Setup(e => e.CreateUser(_fixture.User)).Returns(_fixture.User);

            //Act
            var result = await _handler.Handle(new CreateUserCommand(_fixture.User), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            _userRepositoryWriter.Verify(e => e.CreateUser(_fixture.User), Times.Exactly(1));
        }
    }
}