using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.Hints;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class MyProfileViewModel : MvxViewModel<string,string>
    {

        public string ScreenTitle
        {
            get { return "My Profile"; }
        }

        public IMvxAsyncCommand Close
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Close(this, "teste retorno profile")); }
        }

        public IMvxAsyncCommand ShowRootCommand { get; private set; }


        IMvxNavigationService _navigationService;

        public MyProfileViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowRootCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());
        }

        public override void Prepare(string message)
        {
            base.Prepare();
        }

        public override void ViewDestroy()
        {
            base.ViewDestroy();
        }

        //protected override void SaveStateToBundle(IMvxBundle bundle)
        //{
        //    base.SaveStateToBundle(bundle);
        //}

        //protected override void ReloadFromBundle(IMvxBundle state)
        //{
        //    base.ReloadFromBundle(state);
        //}

        //public async override System.Threading.Tasks.Task Initialize()
        //{
        //    await base.Initialize();

        //    await Task.Delay(8500);
        //}

        //public override void ViewDestroy()
        //{
        //    base.ViewDestroy();
        //}

        public override void ViewDisappeared()
        {
            base.ViewDisappeared();
        }

        //public override void Start()
        //{
        //    base.Start();
        //}
    }
}
