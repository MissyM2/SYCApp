using System;
using Moq;
using Shouldly;
using SYCApp.Core.Contracts.Identity;
using SYCApp.Core.Enums;
using SYCApp.Core.DataTransferObjects;
using SYCApp.Core.Processors;
using SYCApp.Domain;

namespace SYCApp.Core
{
    public class UserRequestProcessorTests
    {
        private UserRequestProcessor _processor;
        private AddUserRequestDto _request;
        private Mock<IUserRepository> _userRepositoryMock;

        private List<UserModel> _existingUserModels;

        public AddUserResultDto result { get; private set; }

        public UserRequestProcessorTests()
        {
            //Arrange
            _request = new AddUserRequestDto
            {
                FirstName="FirstNameU1",
                LastName="LastNameU1",
                UserEmail = "test@email.com",
                HashedPassword = "Password1"
            };
            _existingUserModels = new List<UserModel>() { new UserModel() {
                Id = 1,
                FirstName="FirstNameU1",
                LastName="LastNameU1",
                UserEmail = "test@email.com",
                HashedPassword = "Password1"
            } };

            _userRepositoryMock = new Mock<IUserRepository>();
            //_userRepositoryMock.Setup(q => q.GetExistingUserModelsByUsername(_request.UserEmail))
            //    .Returns(_existingUserModels);

            _processor = new UserRequestProcessor(_userRepositoryMock.Object);
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
        public async Task Should_Save_User_Request()
        {
            // ***** Arrange *****
            // arrange was mostly done more globally
            _existingUserModels.Clear();

            UserModel savedUser = null;

            _userRepositoryMock.Setup(q => q.AddAsync(It.IsAny<UserModel>()))
                .Callback<UserModel>(user =>
                {
                    savedUser = user;
                });

            // ***** Act *****
            await _processor.AddUser(_request);

            _userRepositoryMock.Verify(q => q.AddAsync(It.IsAny<UserModel>()), Times.Once);

            // ***** Assert ******
            savedUser.ShouldNotBeNull();
            savedUser.FirstName.ShouldBe(_request.FirstName);
            savedUser.LastName.ShouldBe(_request.LastName);
            savedUser.UserEmail.ShouldBe(_request.UserEmail);
            savedUser.HashedPassword.ShouldBe(_request.HashedPassword);
        }

        [Fact]
        public async Task Should_Not_Save_User_Request_If_User_Already_Exists()
        {

            // ***** Act *****
            await _processor.AddUser(_request);

            _userRepositoryMock.Verify(q => q.AddAsync(It.IsAny<UserModel>()), Times.Never);
        }


        [Fact]
        public async Task Should_Return_UserResponse_With_Request_Values()
        {
            //Act
            AddUserResultDto result = await _processor.AddUser(_request);

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
        public async Task Should_Return_SuccessOrFailure_Flag_In_Result(AddUserResultFlag addUserSuccessFlag, bool isExisting)
        {
            if (!isExisting)
            {
                _existingUserModels.Clear();
            }

            var result = await _processor.AddUser(_request);

            

            // ***** Assert *****
            addUserSuccessFlag.ShouldBe(result.Flag);

        }

    }
}

