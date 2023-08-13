using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
        BindingContext = new RegistrationPageVM(
         new NavigationService(),
         new MessageService(),
         new UserPreferences(),
         new Repository<UserModel>());
    }
}
