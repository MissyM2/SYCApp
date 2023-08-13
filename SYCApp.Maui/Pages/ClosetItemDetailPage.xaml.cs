﻿using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels;
using SYCApp.Maui.Services;

namespace SYCApp.Maui.Pages;

public partial class ClosetItemDetailPage : ContentPage
{
	public ClosetItemDetailPage()
	{
		InitializeComponent();
        BindingContext = new ClosetItemDetailPageVM(
          new NavigationService(),
          new MessageService(),
          new UserPreferences(),
          new Repository<ClosetItemModel>());
    }
}
