using System;
using SYCApp.Maui.Interfaces;
using SYCApp.Maui.Pages;

namespace SYCApp.Maui.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task GoToHomePageAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        }

        public async Task GoToLoginPageAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public async Task GoToRegistrationPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }

        public async Task GoToMainFlowAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
        }

        public async Task GoToClosetItemListPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(ClosetItemListPage)}");
        }

        public async Task GoToAddClosetItemPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddClosetItemPage)}");
        }

        // look at this
        //private Task GoToAsync<TViewModel>(string routePrefix, string parameters) where TViewModel : BaseVM
        //{
        //    var route = routePrefix + typeof(TViewModel).Name;
        //    if (!string.IsNullOrWhiteSpace(parameters))
        //    {
        //        route += $"?{parameters}";
        //    }
        //    return Shell.Current.GoToAsync(route);
        //}
    }
}

