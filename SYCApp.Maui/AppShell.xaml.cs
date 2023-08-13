using SYCApp.Maui.Pages;

namespace SYCApp.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(ClosetItemListPage), typeof(ClosetItemListPage));
        Routing.RegisterRoute(nameof(AddClosetItemPage), typeof(AddClosetItemPage));
        Routing.RegisterRoute(nameof(AdminUsersPage), typeof(AdminUsersPage));
        Routing.RegisterRoute(nameof(AdminLoginsPage), typeof(AdminLoginsPage));
    }
}

