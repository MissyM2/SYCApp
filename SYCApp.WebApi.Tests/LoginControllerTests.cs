using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using SYCApp.Core.Enums;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Core.Processors;
using SYCApp.WebApi.Controllers;

namespace SYCApp.WebApi.Tests
{
    public class LoginControllerTests
    {
        private Mock<ILoginRequestProcessor> _loginProcessor;
        private LoginController _controller;
        private LoginRequestDto _request;
        private LoginResultDto _result;

        public LoginControllerTests()
        {
            _loginProcessor = new Mock<ILoginRequestProcessor>();
            _controller = new LoginController(_loginProcessor.Object);
            _request = new LoginRequestDto();
            _result = new LoginResultDto();

            //MISSY
            //_loginProcessor.Setup(x => x.LoginUser(_request)).Returns(_result);
        }

        [Theory]
        [InlineData(1, true, typeof(OkObjectResult), LoginResultFlag.Success)]
        [InlineData(0, false, typeof(BadRequestObjectResult), LoginResultFlag.Failure)]
        public async Task Should_Call_Login_Method_When_Valid(int expectedMethodCalls, bool isModelValid,
            Type expectedActionResultType, LoginResultFlag loginResultFlag)
        {
            // Arrange
            if (!isModelValid)
            {
                _controller.ModelState.AddModelError("Key", "ErrorMessage");
            }

            _result.Flag = loginResultFlag;


            // Act
            var result = await _controller.LoginUser(_request);

            // Assert
            result.ShouldBeOfType(expectedActionResultType);
            _loginProcessor.Verify(x => x.LoginUser(_request), Times.Exactly(expectedMethodCalls));

        }
    }
}

