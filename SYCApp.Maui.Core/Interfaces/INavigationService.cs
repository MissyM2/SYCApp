using System;
namespace SYCApp.Maui.Interfaces
{
    public interface INavigationService
    {
        Task GoToRegistrationPageAsync();
        Task GoToLoginPageAsync();
        Task GoToHomePageAsync();
        Task GoBackAsync();
        Task GoToMainFlowAsync();
        Task GoToClosetItemListPageAsync();
        Task GoToAddClosetItemPageAsync();

    }
}

