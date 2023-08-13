using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SYCApp.Core.Validation;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.Localization;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Core.ViewModels
{
	public partial class LoginPageVM : BaseVM
	{

        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<LoginModel> _loginModelRepository;
        private readonly IRepository<UserModel> _userModelRepository;
        

        // Localization Strings
        public string Login_Email => Localization.Strings.Login_Email;
        public string Login_Password => Localization.Strings.Login_Password;
        public string Login_Login => Localization.Strings.Login_Login;

        [ObservableProperty]
        ValidatableObject<string> userEmail;

        [ObservableProperty]
        ValidatableObject<string> userPassword;

        public LoginPageVM(
            INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<LoginModel> loginModelRepository,
            IRepository<UserModel> userModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;

            _loginModelRepository = loginModelRepository;
            _userModelRepository = userModelRepository;

            AddValidations();

        }

        [RelayCommand]
        public async Task GoToRegistration()
        {
            await _navigationService.GoToRegistrationPageAsync();
        }

        [RelayCommand]
        public async Task LoginUser()
        {
            if (!EntriesCorrectlyPopulated())
            {
                return;
            }
            IsBusy = true;

            var user = (await _userModelRepository.GetAllAsync())
                .FirstOrDefault(x => x.UserEmail == UserEmail.Value);

            if (user == null)
            {
                await DisplayCredentialsError();
                IsBusy = false;
                return;
            }
            else
            {
                var userLogin = new LoginModel()
                {
                    Username = UserEmail.Value,
                    LoginDateTime = DateTime.Now,
                };
                await _loginModelRepository.SaveAsync(userLogin);
                await _navigationService.GoToMainFlowAsync();
            }

        }

        private async Task DisplayCredentialsError()
        {
            await _messageService.DisplayAlert(Strings.Login_Error, Strings.Login_WrongCredentials, "Ok");
            UserPassword.Value = "";
        }

        private void AddValidations()
        {
            UserEmail = new ValidatableObject<string>();
            UserPassword = new ValidatableObject<string>();

            UserEmail.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            UserEmail.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in correct format." });

            UserPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });
        }

        private bool EntriesCorrectlyPopulated()
        {
            UserEmail.Validate();
            UserPassword.Validate();

            return UserEmail.IsValid && UserPassword.IsValid;
        }
    }
}

