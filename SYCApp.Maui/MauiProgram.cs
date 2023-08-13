using Microsoft.Extensions.Logging;
using SYCApp.Maui.Interfaces;
using SYCApp.Maui.Pages;
using SYCApp.Maui.Services;

namespace SYCApp.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IMessageService, MessageService>();

        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<RegistrationPage>();
        builder.Services.AddSingleton<SettingsPage>();
        builder.Services.AddSingleton<ClosetItemListPage>();
        builder.Services.AddSingleton<AddClosetItemPage>();
        builder.Services.AddSingleton<AdminUsersPage>();
        builder.Services.AddSingleton<AdminLoginsPage>();

        return builder.Build();
	}
}

