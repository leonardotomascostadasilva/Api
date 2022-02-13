using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Controllers.v1;
using Api.Models.Request.User;
using Api.Tests.Controllers.v1.Fixture;
using Application.Commands.User;
using Application.Queries.User;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Tests.Controllers.v1
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly UserController _controller;
        private readonly UserControllerFixture _fixture;

        public UserControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _fixture = new UserControllerFixture();
            _controller = new UserController(_mediator.Object);
        }

        [Fact]
        public async Task CreateUserAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<CreateUserCommand>(u =>
                    u.User.Document == _fixture.CreateUserRequest.Document &&
                    u.User.Email == _fixture.CreateUserRequest.Email &&
                    u.User.Name == _fixture.CreateUserRequest.Name &&
                    u.User.Password == _fixture.CreateUserRequest.Password &&
                    u.User.UserNameLogin == _fixture.CreateUserRequest.UserNameLogin), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.User);

            //Act
            var response = await _controller.CreateUserAsync(_fixture.CreateUserRequest);

            //Assert
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task DontCreateUserAsyncWhenUserDocumentExists()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((User)null);

            //Act
            var response = await _controller.CreateUserAsync(_fixture.CreateUserRequest);

            //Assert
            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public async Task UpdateUserAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<UpdateUserCommand>(u =>
                    u.User.Email == _fixture.UpdateUserRequest.Email &&
                    u.User.Name == _fixture.UpdateUserRequest.Name &&
                    u.User.UserNameLogin == _fixture.UpdateUserRequest.UserNameLogin), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.User);

            //Act
            var response = await _controller.UpdateUserAsync(_fixture.UserId, _fixture.UpdateUserRequest);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task DontUpdateUserAsyncWhenUserNotExists()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((User)null);

            //Act
            var response = await _controller.UpdateUserAsync(_fixture.UserId, _fixture.UpdateUserRequest);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task DeleteUserAsyncAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<DeleteUserCommand>(u =>
                    u.UserId == _fixture.UserId), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            //Act
            var response = await _controller.DeleteUserAsync(_fixture.UserId);

            //Assert
            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public async Task DontDeleteUserAsyncWhenUserNotExists()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.IsAny<DeleteUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            //Act
            var response = await _controller.DeleteUserAsync(_fixture.UserId);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public async Task GetUsersAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.IsAny<GetUsersQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.Users);

            //Act
            var response = await _controller.GetUsersAsync();

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetUserByIdAsyncAsyncWhenSuccess()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.Is<GetUserByIdQuery>(u =>
                    u.UserId == _fixture.UserId), It.IsAny<CancellationToken>())).ReturnsAsync(_fixture.User);

            //Act
            var response = await _controller.GetUserByIdAsync(_fixture.UserId);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task DontGetUserByIdAsyncWhenUserNotExists()
        {
            //Arrange
            _mediator.Setup(e =>
                e.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((User)null);

            //Act
            var response = await _controller.GetUserByIdAsync(_fixture.UserId);

            //Assert
            Assert.IsType<NotFoundResult>(response);
        }
    }
}