using System;
using Moq;
using FluentAssertions;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Interfaces;
using SYCApp.Maui.Tests.Mocks;

namespace SYCApp.Maui.Tests.ViewModels
{
    public partial class LoginPageVM_Should
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<IMessageService> _mockMessageService;
        private readonly Mock<IUserPreferences> _mockUserPreferences;

        private readonly Mock<IRepository<UserModel>> _mockUserModelRepository;
        private readonly Mock<IRepository<LoginModel>> _mockLoginModelRepository;


        public LoginPageVM_Should()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockMessageService = new Mock<IMessageService>();
            _mockUserPreferences = new Mock<IUserPreferences>();
            _mockUserModelRepository = new Mock<IRepository<UserModel>>();
            _mockLoginModelRepository = new Mock<IRepository<LoginModel>>();

        }

        [Fact]
        public void GoToRegistrationCommand_navigates_to_the_login_page()
        {
            LoginPageVM _sut = CreateLoginPageVM();

            _sut.GoToRegistrationCommand.Execute(null);
            _mockNavigationService.VerifyThatGoToRegistrationPageAsyncWasCalled();

        }

        [Fact]
        public void LoginUserCommand_validates_email_and_password()
        {
            LoginPageVM _sut = CreateLoginPageVM();

            _sut.LoginUserCommand.Execute(null);

            _sut.Email.Errors.Should().NotBeEmpty();
            _sut.Password.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void LoginUserCommand_shows_error_when_email_is_not_correct()
        {
            _mockUserModelRepository.GetAllAsyncReturns(new List<UserModel>());
            LoginPageVM _sut = CreateLoginPageVM();
            _sut.Email.Value = "tester@email.com";
            _sut.Password.Value = "pass";

            _sut.LoginUserCommand.Execute(null);

            _mockMessageService.VerifyThatDisplayAlertWasCalledWithMessage("Credentials are wrong.");
        }

        private LoginPageVM CreateLoginPageVM()
        {
            return new LoginPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockLoginModelRepository.Object,
                _mockUserModelRepository.Object);
        }




    }
}

