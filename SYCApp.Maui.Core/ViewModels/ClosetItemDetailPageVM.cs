using System;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Core.ViewModels
{
	public class ClosetItemDetailPageVM
	{

        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<ClosetItemModel> _closetItemModelRepository;

        public ClosetItemDetailPageVM(INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<ClosetItemModel> closetItemModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _closetItemModelRepository = closetItemModelRepository;

        }
    }
}

