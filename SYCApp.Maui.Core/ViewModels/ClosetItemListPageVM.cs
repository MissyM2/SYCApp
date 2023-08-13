using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using SYCApp.Maui.Core.Database;
using SYCApp.Maui.Core.Domain;
using SYCApp.Maui.Core.ViewModels.Base;
using SYCApp.Maui.Interfaces;

namespace SYCApp.Maui.Core.ViewModels
{
	public partial class ClosetItemListPageVM : BaseVM
	{
        private readonly INavigationService _navigationService;
        private readonly IMessageService _messageService;
        private readonly IUserPreferences _userPreferences;

        private readonly IRepository<ClosetItemModel> _closetItemModelRepository;
        private readonly IRepository<LoginModel> _loginModelRepository;

        public ObservableCollection<ClosetItemModel> ClosetItemList { get; set; }

        public ClosetItemListPageVM(INavigationService navigationService,
            IMessageService messageService,
            IUserPreferences userPreferences,
            IRepository<ClosetItemModel> closetItemModelRepository,
            IRepository<LoginModel> loginModelRepository)
        {
            _navigationService = navigationService;
            _messageService = messageService;
            _userPreferences = userPreferences;
            _closetItemModelRepository = closetItemModelRepository;
            _loginModelRepository = loginModelRepository;

            PageTitle = "Clost Item List";

            ClosetItemList = new ObservableCollection<ClosetItemModel>();

        }
        [RelayCommand]
        private async Task LogoutUser()
        {
            await _loginModelRepository.DeleteAllAsync();
            await _navigationService.GoToLoginPageAsync();

        }

        //public override async Task InitializeAsync(object parameter)
        //{
        //    var items = await _closetItemModelRepository.GetAllAsync();
        //    ClosetItemList = new ObservableCollection<ClosetItemModel>(items);
        //}

        [RelayCommand]
        public async Task AddClosetItem()
        {
            await _navigationService.GoToAddClosetItemPageAsync();
        }

        //        [RelayCommand]
        //        public async Task Selected(ClosetItemModel closetItem)
        //        {
        //            if (closetItem == null)
        //                return;

        //            //var route = $"{nameof(ClosetItemDetailsPage)}?ClosetItemId={closetItem.Id}";
        //            //await Shell.Current.GoToAsync(route);
        //        }

        //        //[RelayCommand]
        //        //async Task Remove(ClosetItem closetItem)
        //        //{
        //        //    await closetItemService.RemoveClosetItem(closetItem.Id);
        //        //    await Refresh();
        //        //}

        [RelayCommand]
        public async Task Refresh()
        {
            IsBusy = true;


#if DEBUG
            await Task.Delay(500);
#endif

            ClosetItemList.Clear();

            var items = await _closetItemModelRepository.GetAllAsync();

            foreach (var item in items) ClosetItemList.Add(item);


            IsBusy = false;

            //toaster?.MakeToast("Refreshed!");
        }
    }
}

