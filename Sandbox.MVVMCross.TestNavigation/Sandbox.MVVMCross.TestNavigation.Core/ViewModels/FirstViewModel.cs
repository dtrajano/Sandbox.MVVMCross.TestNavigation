using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

        private readonly IMvxNavigationService _navigationService;


        public IMvxAsyncCommand redirectToTabRoot
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());  }
        }

        public FirstViewModel(IMvxNavigationService navigationService) {
            _navigationService = navigationService;
        }
    }
}
