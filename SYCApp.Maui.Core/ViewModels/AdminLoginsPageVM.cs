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
	public partial class AdminLoginsPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<LoginModel> _loginModelRepository;

        public ObservableCollection<LoginModel> LoginList { get; set; }

        [ObservableProperty]
        string selectedListItem;

        [ObservableProperty]
        int loginId;

        public AdminLoginsPageVM(
            INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<LoginModel> loginModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _loginModelRepository = loginModelRepository;

            LoginList = new ObservableCollection<LoginModel>();

        }
        [RelayCommand]
        public async Task GetLogins()
        {
#if DEBUG
            await Task.Delay(500);
#endif

            LoginList.Clear();

            var items = await _loginModelRepository.GetAllAsync();

            foreach (var item in items) LoginList.Add(item);
        }

        [RelayCommand]
        public async Task DeleteAllLogins()
        {
            await _loginModelRepository.DeleteAllAsync();

        }

        [RelayCommand]
        public async Task<LoginModel> GetLoginById(int id)
        {
            var selectedListItem = await _loginModelRepository.GetById(id);
            return selectedListItem;

        }

        [RelayCommand]
        public void GoToDetails()
        {
            Console.WriteLine("Go to detailils");

        }


        //[RelayCommand]
        //public async Task<UserModel> GetLoginById(int id)
        //{
        //    var selectedLogin = await _loginModelRepository.GetById(id);
        //    return selectedLogin;

        //}

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

