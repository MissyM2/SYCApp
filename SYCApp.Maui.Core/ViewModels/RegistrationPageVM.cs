using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SYCApp.Core.Validation;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Core.ViewModels
{
	public partial class RegistrationPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<UserModel> _userModelRepository;

        [ObservableProperty]
        ValidatableObject<string> name;

        [ObservableProperty]
        ValidatableObject<string> email;

        [ObservableProperty]
        ValidatableObject<string> password;

        [ObservableProperty]
        ValidatableObject<string> confirmationPassword;


        public RegistrationPageVM(
            INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<UserModel> userModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _userModelRepository = userModelRepository;

            AddValidations();

        }

        [RelayCommand]
        private async Task RegisterUser()
        {
            EntriesCorrectlyPopulated();
            if (!EntriesCorrectlyPopulated())
            {
                return;
            }
            IsBusy = true;
            var user = new UserModel()
            {
                Email = Email.Value,
                FirstName = Name.Value,
                //HashedPassword = SecurePasswordHasher.Hash(Password.Value)
                HashedPassword = Password.Value
            };
            await _userModelRepository.SaveAsync(user);

            await _navigationService.GoToLoginPageAsync();
            IsBusy = false;
        }

        [RelayCommand]
        private async Task GoToLogin()
        {
            await _navigationService.GoToLoginPageAsync();
        }

        private void AddValidations()
        {
            Name = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            ConfirmationPassword = new ValidatableObject<string>();

            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is empty." });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            Email.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in a correct format." });

            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });

            ConfirmationPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });

        }

        private bool EntriesCorrectlyPopulated()
        {
            Name.Validate();
            Email.Validate();
            Password.Validate();
            ConfirmationPassword.Validate();


            return Name.IsValid && Email.IsValid && Password.IsValid && ConfirmationPassword.IsValid;
        }
    }

}

