using System;
using FluentAssertions;
using Moq;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Interfaces;
using SYCApp.Maui.Tests.Mocks;

namespace SYCApp.Maui.Tests.ViewModels
{
    public class RegistrationPageVM_Should
    {
        private readonly Mock<INavigationService> _mockNavigationService;
        private readonly Mock<IMessageService> _mockMessageService;
        private readonly Mock<IUserPreferences> _mockUserPreferences;

        private readonly Mock<IRepository<UserModel>> _mockUserModelRepository;

        public RegistrationPageVM_Should()
        {
            _mockNavigationService = new Mock<INavigationService>();
            _mockMessageService = new Mock<IMessageService>();
            _mockUserPreferences = new Mock<IUserPreferences>();
            _mockUserModelRepository = new Mock<IRepository<UserModel>>();
        }

        private RegistrationPageVM CreateLoginPageVM()
        {
            return new RegistrationPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockUserModelRepository.Object);
        }

        [Fact]
        public void GoToLoginCommand_navigates_to_the_login_page()
        {
            RegistrationPageVM _sut = CreateRegistrationPageVM();

            _sut.GoToLoginCommand.Execute(null);
            _mockNavigationService.VerifyThatGoToLoginPageAsyncWasCalled();

        }


        [Fact]
        public void RegisterUserCommand_validates_name_and_email_and_password()
        {
            RegistrationPageVM _sut = CreateRegistrationPageVM();

            _sut.RegisterUserCommand.Execute(null);

            _sut.Name.Errors.Should().NotBeEmpty();
            _sut.Email.Errors.Should().NotBeEmpty();
            _sut.Password.Errors.Should().NotBeEmpty();
            // where is email test?
        }

        [Fact]
        public void RegisterUserCommand_registers_new_user()
        {
            RegisterNewUser();

            _mockUserModelRepository.VerifyThatSaveAsyncWasCalled();
        }

        private void RegisterNewUser()
        {
            RegistrationPageVM _sut = CreateRegistrationPageVM();

            _sut.Name.Value = "Tester";
            _sut.Email.Value = "test@email.com";
            _sut.Password.Value = "pass";

            _sut.RegisterUserCommand.Execute(null);
        }

        private RegistrationPageVM CreateRegistrationPageVM()
        {
            return new RegistrationPageVM(
                _mockNavigationService.Object,
                _mockMessageService.Object,
                _mockUserPreferences.Object,
                _mockUserModelRepository.Object
                );
        }
    }
}

