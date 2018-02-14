using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService _navigationService;

        public string ScreenTitle
        {
            get;
            set;
        }

        public IMvxAsyncCommand redirectFirstOption
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<FirstViewModel>()); }
        }

        public HomeViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(string title)
        {
            base.Prepare();
            ScreenTitle = title;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
