using System;
using CommunityToolkit.Mvvm.Input;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Core.ViewModels
{
	public partial class DashboardPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<LoginModel> _loginModelRepository;

        public DashboardPageVM(
            INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<LoginModel> loginModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _loginModelRepository = loginModelRepository;

        }

        [RelayCommand]
        private async Task LogoutUser()
        {
            await _loginModelRepository.DeleteAllAsync();
            await _navigationService.GoToLoginPageAsync();

        }
    }
}

