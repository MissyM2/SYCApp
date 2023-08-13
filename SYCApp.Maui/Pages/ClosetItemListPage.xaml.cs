using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class ClosetItemListPage : ContentPage
{
	public ClosetItemListPage()
	{
		InitializeComponent();
        BindingContext = new ClosetItemListPageVM(
          new NavigationService(),
          new MessageService(),
          new UserPreferences(),
          new Repository<ClosetItemModel>(),
          new Repository<LoginModel>());
    }

    private async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var vm = (ClosetItemListPageVM)BindingContext;
        await vm.RefreshCommand.ExecuteAsync(null);
    }
}
