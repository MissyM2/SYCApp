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
        ValidatableObject<string> firstName;

        [ObservableProperty]
        ValidatableObject<string> lastName;

        [ObservableProperty]
        ValidatableObject<string> userEmail;

        [ObservableProperty]
        ValidatableObject<string> hashedPassword;

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
                FirstName = FirstName.Value,
                LastName= LastName.Value,
                UserEmail = UserEmail.Value,
                HashedPassword = HashedPassword.Value,
                
                //HashedPassword = SecurePasswordHasher.Hash(Password.Value)
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
            FirstName = new ValidatableObject<string>();
            LastName = new ValidatableObject<string>();
            UserEmail = new ValidatableObject<string>();
            HashedPassword = new ValidatableObject<string>();
            ConfirmationPassword = new ValidatableObject<string>();

            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "FirstName is empty." });
            LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "LastName is empty." });

            UserEmail.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is empty." });
            UserEmail.Validations.Add(new EmailRule<string> { ValidationMessage = "Email is not in a correct format." });

            HashedPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });

            ConfirmationPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Confirmation Password is empty." });
            ConfirmationPassword.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password is empty." });

        }

        private bool EntriesCorrectlyPopulated()
        {
            FirstName.Validate();
            LastName.Validate();
            UserEmail.Validate();
            HashedPassword.Validate();
            ConfirmationPassword.Validate();


            return
                FirstName.IsValid &&
                LastName.IsValid &&
                UserEmail.IsValid &&
                HashedPassword.IsValid &&
                ConfirmationPassword.IsValid;
        }
    }

}

