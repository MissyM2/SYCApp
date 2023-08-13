using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        BindingContext = new SettingsPageVM(
         new NavigationService(),
         new MessageService(),
         new UserPreferences(),
         new Repository<LoginModel>());
    }
}
