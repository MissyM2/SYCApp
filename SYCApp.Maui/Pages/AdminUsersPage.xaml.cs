using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class AdminUsersPage : ContentPage
{
	public AdminUsersPage()
	{
		InitializeComponent();
        BindingContext = new AdminUsersPageVM(
          new NavigationService(),
          new MessageService(),
          new UserPreferences(),
          new Repository<LoginModel>(),
          new Repository<UserModel>());
    }
}
