using System.Threading;
using System.Threading.Tasks;
using Api.Controllers.v1;
using Api.Models.Request.Login;
using Api.Tests.Controllers.v1.Fixture;
using Application.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Tests.Controllers.v1
{
    public class LoginControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly LoginController _controller;
        private readonly LoginControllerFixture _fixture;

        public LoginControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _fixture = new LoginControllerFixture();
            _controller = new LoginController(_mediator.Object);
        }

        [Fact]
        public async Task LoginUserAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<LoginUserCommand>(l =>
                    l.UserLoginName == _fixture.UserLoginName && l.Password == _fixture.Password), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            //Act
            var response = await _controller.LoginUserAsync(_fixture.LoginRequest);

            //Assert
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task LoginUserAsyncWhenCredentialsIsInvalid()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<LoginUserCommand>(l =>
                    l.UserLoginName == _fixture.UserLoginName && l.Password == _fixture.Password), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            //Act
            var response = await _controller.LoginUserAsync(_fixture.LoginRequest);

            //Assert
            Assert.IsType<BadRequestResult>(response);
        }
    }
}