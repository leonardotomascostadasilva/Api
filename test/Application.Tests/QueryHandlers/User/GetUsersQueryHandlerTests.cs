using System.Threading;
using System.Threading.Tasks;
using Application.Queries.User;
using Application.QueryHandlers.User;
using Application.Tests.QueryHandlers.User.Fixture;
using Moq;
using Persistence.IRepository.User;
using Xunit;

namespace Application.Tests.QueryHandlers.User
{
    public class GetUsersQueryHandlerTests
    {
        private readonly GetUsersQueryHandlerFixture _fixture;
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly GetUsersQueryHandler _handler;

        public GetUsersQueryHandlerTests()
        {
            _fixture = new GetUsersQueryHandlerFixture();
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _handler = new GetUsersQueryHandler(_userRepositoryReader.Object);
        }

        [Fact]
        public async Task GetUsersQueryHandlerMustReturnSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUsers()).Returns(_fixture.Users);
            
            //Act
            var result = await _handler.Handle(new GetUsersQuery(), CancellationToken.None);

            //Assert
            Assert.NotNull(result);
        }
    }
}