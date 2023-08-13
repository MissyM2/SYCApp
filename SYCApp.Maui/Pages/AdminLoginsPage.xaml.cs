﻿using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class AdminLoginsPage : ContentPage
{
	public AdminLoginsPage()
	{
		InitializeComponent();
        BindingContext = new AdminLoginsPageVM(
          new NavigationService(),
          new MessageService(),
          new UserPreferences(),
          new Repository<LoginModel>());
    }
}
