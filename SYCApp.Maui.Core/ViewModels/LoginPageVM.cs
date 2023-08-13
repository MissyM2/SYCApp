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
        ValidatableObject<string> email;

        [ObservableProperty]
        ValidatableObject<string> password;

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
                .FirstOrDefault(x => x.Email == Email.Value);

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
                    Username = Email.Value,
                    LoginDateTime = DateTime.Now,
                };
                await _loginModelRepository.SaveAsync(userLogin);
                await _navigationService.GoToMainFlowAsync();
            }

        }

        private async Task DisplayCredentialsError()
        {
            await _messageService.DisplayAlert(Strings.Login_Error, Strings.Login_WrongCredentials, "Ok");
            Password.Value = "";
        }

        private void AddValidations()
        {
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            Email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in correct format." });

            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });
        }

        private bool EntriesCorrectlyPopulated()
        {
            Email.Validate();
            Password.Validate();

            return Email.IsValid && Password.IsValid;
        }
    }
}

