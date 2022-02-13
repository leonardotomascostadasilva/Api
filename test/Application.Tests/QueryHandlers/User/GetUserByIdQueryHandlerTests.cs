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
    public class GetUserByIdQueryHandlerTests
    {
        private readonly GetUserByIdQueryHandlerFixture _fixture;
        private readonly Mock<IUserRepositoryReader> _userRepositoryReader;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _fixture = new GetUserByIdQueryHandlerFixture();
            _userRepositoryReader = new Mock<IUserRepositoryReader>();
            _handler = new GetUserByIdQueryHandler(_userRepositoryReader.Object);
        }

        [Fact]
        public async Task DontGetUserByIdQueryHandlerWhenUserNotFound()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUserById(_fixture.UserId)).Returns((Domain.Entities.User)null);

            //Act
            var result = await _handler.Handle(new GetUserByIdQuery(_fixture.UserId), CancellationToken.None);
            
            //Arrange
            Assert.Null(result);
        }
        
        [Fact]
        public async Task GetUserByIdQueryHandlerWhenSuccess()
        {
            //Arrange
            _userRepositoryReader.Setup(e => e.GetUserById(_fixture.UserId)).Returns(_fixture.User);

            //Act
            var result = await _handler.Handle(new GetUserByIdQuery(_fixture.UserId), CancellationToken.None);
            
            //Arrange
            Assert.NotNull(result);
        }
    }
}