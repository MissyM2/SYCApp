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
	public partial class AddClosetItemPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<ClosetItemModel> _closetItemModelRepository;
        private readonly IRepository<LoginModel> _loginModelRepository;

        [ObservableProperty]
        ValidatableObject<string> name;

        [ObservableProperty]
        ValidatableObject<string> season;

        [ObservableProperty]
        ValidatableObject<string> itemType;

        [ObservableProperty]
        ValidatableObject<string> size;

        [ObservableProperty]
        ValidatableObject<string> desc;


        public AddClosetItemPageVM(INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<ClosetItemModel> closetItemModelRepository,
            IRepository<LoginModel> loginModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _closetItemModelRepository = closetItemModelRepository;
            _loginModelRepository = loginModelRepository;

            //PageTitle = "Add Closet List";

            AddValidations();

        }

        [RelayCommand]
        public async Task GoBack()
        {
            var shouldGoBack = await _messageService.DisplayAlert("Confirm",
                "Are you sure you want to navigate back? Any unsaved changes will be lost.", "Ok", "Cancel");
            if (shouldGoBack)
            {
                await _navigationService.GoBackAsync();
            }
        }

        [RelayCommand]
        private async Task LogoutUser()
        {
            await _loginModelRepository.DeleteAllAsync();
            await _navigationService.GoToLoginPageAsync();
        }

        [RelayCommand]
        public async Task AddClosetItem()
        {
            EntriesCorrectlyPopulated();

            if (!EntriesCorrectlyPopulated())
            {
                return;
            }

            IsBusy = true;

            //var userId = _userPreferences.Get(Constants.USER_ID, string.Empty);

            var closetItem = new ClosetItemModel()
            {
                Name = Name.Value,
                Season = Season.Value,
                ItemType=ItemType.Value,
                Size=Size.Value,
                Desc= Desc.Value
            };

            await _closetItemModelRepository.SaveAsync(closetItem);

            Name.Value = null;
            Season.Value = null;
            ItemType.Value = null;
            Size.Value = null;
            Desc.Value = null;

            await _navigationService.GoBackAsync();

            IsBusy = false;
        }


        private void AddValidations()
        {
            Name = new ValidatableObject<string>();
            Season = new ValidatableObject<string>();
            ItemType = new ValidatableObject<string>();
            Size = new ValidatableObject<string>();
            Desc = new ValidatableObject<string>();

            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name is empty." });
            Season.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Season is empty." });
            ItemType.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "ItemType is empty." });
            Size.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Size is empty." });
            Desc.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Desc is empty." });

        }

        private bool EntriesCorrectlyPopulated()
        {
            Name.Validate();
            Season.Validate();
            ItemType.Validate();
            Size.Validate();
            Desc.Validate();

            return Name.IsValid &&
                Season.IsValid &&
                ItemType.IsValid &&
                Size.IsValid &&
                Desc.IsValid;
        }
    }
}
