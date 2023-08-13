using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace SYCApp.Maui.Core.ViewModels
{
	public partial class AdminUsersPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<LoginModel> _loginModelRepository;
        private readonly IRepository<UserModel> _userModelRepository;

        [ObservableProperty]
        UserModel selectedListItem;

        [ObservableProperty]
        int userId;

        public ObservableCollection<UserModel> UserList { get; set; }

        public AdminUsersPageVM(INavigationService navigationService,
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

            UserList = new ObservableCollection<UserModel>();

        }

        [RelayCommand]
        public async Task GetUsers()
        {
#if DEBUG
            await Task.Delay(500);
#endif

            UserList.Clear();

            var items = await _userModelRepository.GetAllAsync();

            foreach (var item in items) UserList.Add(item);
        }

        [RelayCommand]
        public async Task DeleteAllUsers()
        {
            await _userModelRepository.DeleteAllAsync();

        }

        [RelayCommand]
        public async Task<UserModel> GetUserById()
        {
            SelectedListItem = await _userModelRepository.GetById(UserId);
            return SelectedListItem;

        }

        [RelayCommand]
        public async Task<int> DeleteUserById()
        {
            SelectedListItem = await _userModelRepository.GetById(UserId);
            var result = await _userModelRepository.DeleteAsync(SelectedListItem);
            return result;

        }

        //[RelayCommand]
        //public async Task<User> GetUserByUsername(string username)
        //{
        //    return await _userService.GetByUsername(username);

        //}

        //[RelayCommand]
        //public async Task<User> GetUserByEmailAddress(string emailAddress)
        //{
        //    return await _userService.GetByEmail(emailAddress);

        //}

        [RelayCommand]
        private async Task LogoutUser()
        {
            await _loginModelRepository.DeleteAllAsync();
            await _navigationService.GoToLoginPageAsync();

        }

    }
}

