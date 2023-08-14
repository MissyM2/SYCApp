using System;
using Moq;
using Shouldly;
using SYCApp.Core.DataServices;
using SYCApp.Core.Enums;
using SYCApp.Core.Models;
using SYCApp.Core.Processors;
using SYCApp.Domain;

namespace SYCApp.Core
{
	public class LoginRequestProcessorTests
    {
        private LoginRequestProcessor _processor;
        private LoginRequest _request;
        private Mock<ILoginService> _loginServiceMock;

        private List<UserModel> _existingUserModels;

        public LoginRequestProcessorTests()
        {
            //Arrange
            _request = new LoginRequest
            {
                Username = "test@request.com",
                LoginDateTime = new DateTime(2021, 10, 20)
            };
            _existingUserModels = new List<UserModel>() { new UserModel() { Id = 1 } };

            _loginServiceMock = new Mock<ILoginService>();
            _loginServiceMock.Setup(q => q.GetExistingUserModels())
                .Returns(_existingUserModels);

            _processor = new LoginRequestProcessor(_loginServiceMock.Object);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            // ***** Arrange and Act *****

            // this test has a null request so you don't have to arrange any input values
            var exception = Should.Throw<ArgumentNullException>(() => _processor.LoginUser(null));

            // ***** Assert *****
            // without Shouldly
            // Assert.Throws<ArgumentNullException>(() => processor.LoginUser(null);
            exception.ParamName.ShouldBe("loginRequest");
        }

        [Fact]
        public void Should_Save_Login_Request()
        {
            // ***** Arrange *****
            // arrange was mostly done more globally
            LoginModel savedLogin = null;
            _loginServiceMock.Setup(q => q.Save(It.IsAny<LoginModel>()))
                .Callback<LoginModel>(login =>
                {
                    savedLogin = login;
                });

            // ***** Act *****
            _processor.LoginUser(_request);

            _loginServiceMock.Verify(q => q.Save(It.IsAny<LoginModel>()), Times.Once);

            // ***** Assert ******
            savedLogin.ShouldNotBeNull();
            savedLogin.Username.ShouldBe(_request.Username);
            savedLogin.LoginDateTime.ShouldBe(_request.LoginDateTime);
            savedLogin.UserId.ShouldBe(_existingUserModels.First().Id);
        }

        [Fact]
        public void Should_Not_Save_Login_Request_If_User_Does_Not_Exist()
        {
            _existingUserModels.Clear();

            // ***** Act *****
            _processor.LoginUser(_request);

            _loginServiceMock.Verify(q => q.Save(It.IsAny<LoginModel>()), Times.Never);
        }


        [Fact]
        public void Should_Return_LoginResponse_With_Request_Values()
        {
            //Act
            LoginResult result = _processor.LoginUser(_request);

            //Assert
            result.ShouldNotBeNull();
            result.Username.ShouldBe(_request.Username);
            result.LoginDateTime.ShouldBe(_request.LoginDateTime);

        }

       

       

        [Theory]
        [InlineData(LoginResultFlag.Failure, false)]
        [InlineData(LoginResultFlag.Success, true)]
        public void Should_Return_SuccessOrFailure_Flag_In_Result(LoginResultFlag bookingSuccessFlag, bool isAvailable)
        {
            if (!isAvailable)
            {
                _existingUserModels.Clear();
            }

            // ***** Act *****
            var result = _processor.LoginUser(_request);

            // ***** Assert *****
            bookingSuccessFlag.ShouldBe(result.Flag);

        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(null, false)]
        public void Should_Return_LoginId_In_Result(int? loginId, bool isExisting)
        {
            if (!isExisting)
            {
                _existingUserModels.Clear();
            }
            else
            {
                _loginServiceMock.Setup(q => q.Save(It.IsAny<LoginModel>()))
               .Callback<LoginModel>(login =>
               {
                   login.Id = loginId.Value;
               });
            }

            // ***** Act *****
            var result = _processor.LoginUser(_request);

            // ***** Assert *****
            result.LoginId.ShouldBe(loginId);
        }
    }
}

