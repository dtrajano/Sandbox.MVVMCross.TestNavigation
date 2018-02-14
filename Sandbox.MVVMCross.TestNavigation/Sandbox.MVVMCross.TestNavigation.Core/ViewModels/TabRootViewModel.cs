using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class TabRootViewModel : MvxViewModel
    {

        private IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
        public IMvxAsyncCommand ShowTabsRootBCommand { get; private set; }


        public TabRootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
            ShowTabsRootBCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());
        }

        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(_navigationService.Navigate<HomeViewModel, string>("Home"));
            tasks.Add(_navigationService.Navigate<MyMenuViewModel, string>("My Menu"));
            tasks.Add(_navigationService.Navigate<PreferencesViewModel, string>("Preferences"));
            await Task.WhenAll(tasks);
        }

        private int _itemIndex;

        public int ItemIndex
        {
            get { return _itemIndex; }
            set
            {
                if (_itemIndex == value) return;
                _itemIndex = value;
                MvxTrace.Trace("Tab item changed to {0}", _itemIndex.ToString());
                RaisePropertyChanged(() => ItemIndex);
            }
        }
    }
}
