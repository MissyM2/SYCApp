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
    public class UserRequestProcessorTests
    {
        private UserRequestProcessor _processor;
        private AddUserRequest _request;
        private Mock<IUserService> _userServiceMock;

        private List<UserModel> _existingUserModels;

        public AddUserResult result { get; private set; }

        public UserRequestProcessorTests()
        {
            //Arrange
            _request = new AddUserRequest
            {
                FirstName="FirstNameU1",
                LastName="LastNameU1",
                UserEmail = "test@email.com",
                HashedPassword = "Password1"
            };
            _existingUserModels = new List<UserModel>() { new UserModel() { Id = 1 } };

            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(q => q.GetExistingUserModels(_request.UserEmail))
                .Returns(_existingUserModels);

            _processor = new UserRequestProcessor(_userServiceMock.Object);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            // ***** Arrange and Act *****

            // this test has a null request so you don't have to arrange any input values
            var exception = Should.Throw<ArgumentNullException>(() => _processor.AddUser(null));

            // ***** Assert *****
            exception.ParamName.ShouldBe("addUserRequest");
        }

        [Fact]
        public void Should_Save_User_Request()
        {
            // ***** Arrange *****
            // arrange was mostly done more globally
            UserModel savedUser = null;

            _userServiceMock.Setup(q => q.Save(It.IsAny<UserModel>()))
                .Callback<UserModel>(user =>
                {
                    savedUser = user;
                });

            // ***** Act *****
            _processor.AddUser(_request);

            _userServiceMock.Verify(q => q.Save(It.IsAny<UserModel>()), Times.Once);

            // ***** Assert ******
            savedUser.ShouldNotBeNull();
            savedUser.FirstName.ShouldBe(_request.FirstName);
            savedUser.LastName.ShouldBe(_request.LastName);
            savedUser.UserEmail.ShouldBe(_request.UserEmail);
            savedUser.HashedPassword.ShouldBe(_request.HashedPassword);
        }

        [Fact]
        public void Should_Not_Save_User_Request_If_User_Already_Exists()
        {
            _existingUserModels.Clear();

            // ***** Act *****
            _processor.AddUser(_request);

            _userServiceMock.Verify(q => q.Save(It.IsAny<UserModel>()), Times.Never);
        }


        [Fact]
        public void Should_Return_UserResponse_With_Request_Values()
        {
            //Act
            AddUserResult result = _processor.AddUser(_request);

            //Assert
            result.ShouldNotBeNull();
            result.FirstName.ShouldBe(_request.FirstName);
            result.LastName.ShouldBe(_request.LastName);
            result.UserEmail.ShouldBe(_request.UserEmail);
            result.HashedPassword.ShouldBe(_request.HashedPassword);

        }





        [Theory]
        [InlineData(AddUserResultFlag.Failure, true)]
        [InlineData(AddUserResultFlag.Success, false)]
        public void Should_Return_SuccessOrFailure_Flag_In_Result(AddUserResultFlag addUserSuccessFlag, bool isExisting)
        {
            if (!isExisting)
            {
                _existingUserModels.Clear();
            }

            var result = _processor.AddUser(_request);

            

            // ***** Assert *****
            addUserSuccessFlag.ShouldBe(result.Flag);

        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(null, false)]
        public void Should_Return_UserId_In_Result(int? userId, bool isExisting)
        {
            if (!isExisting)
            {
                _existingUserModels.Clear();
            }
            else
            {
                _userServiceMock.Setup(q => q.Save(It.IsAny<UserModel>()))
               .Callback<UserModel>(user =>
               {
                   user.Id = userId.Value;
               });
            }

            // ***** Act *****
            var result = _processor.AddUser(_request);

            // ***** Assert *****
            result.UserId.ShouldBe(userId);
        }
    }
}

