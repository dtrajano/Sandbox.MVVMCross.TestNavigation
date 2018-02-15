using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Sandbox.MVVMCross.TestNavigation.Core.Hints;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class TabRootViewModel : MvxViewModel
    {

        private IMvxNavigationService _navigationService;

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }
        public IMvxAsyncCommand ShowTabRootCommand { get; private set; }
        public MvxCommand clearStackPreferencesTabCommand { get; private set; }


        public TabRootViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));

            ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
            ShowTabRootCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());
            clearStackPreferencesTabCommand = new MvxCommand(() => ClearBackStack<PreferencesViewModel>());
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

        protected void ClearBackStack<TViewModel>() where TViewModel : IMvxViewModel
        {
            //ShowViewModel<TViewModel>();
            ChangePresentation(new ClearNavBackStackHint(this.ItemIndex));
        }
    }
}
