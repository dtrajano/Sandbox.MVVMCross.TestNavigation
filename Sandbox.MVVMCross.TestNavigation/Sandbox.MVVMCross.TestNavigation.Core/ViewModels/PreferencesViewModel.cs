using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class PreferencesViewModel : MvxViewModel<string>
    {

        public string ScreenTitle
        {
            get;
            set;
        }

        IMvxNavigationService _navigationService;

        public PreferencesViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(string title)
        {
            base.Prepare();
            ScreenTitle = title;
        }
    }
}
