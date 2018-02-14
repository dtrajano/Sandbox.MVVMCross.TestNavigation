using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class MyProfileViewModel : MvxViewModel
    {

        public string ScreenTitle
        {
            get { return "My Profile"; }
        }

        public IMvxAsyncCommand Close
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Close(this)); }
        }

        IMvxNavigationService _navigationService;

        public MyProfileViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare()
        {
            base.Prepare();
        }
    }
}
