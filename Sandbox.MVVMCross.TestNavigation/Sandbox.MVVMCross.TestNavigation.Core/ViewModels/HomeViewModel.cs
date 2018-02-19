using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IRSAEncryption _rsaEncryption;

        public string ScreenTitle
        {
            get;
            set;
        }

        public string EncryptedText
        {
            get;
            set;
        }

        public string DecryptedText
        {
            get;
            set;
        }

        public IMvxAsyncCommand redirectFirstOption
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<FirstViewModel>()); }
        }

        public HomeViewModel(IMvxNavigationService navigationService, IRSAEncryption rsaEncryption)
        {
            _navigationService = navigationService;
            _rsaEncryption = rsaEncryption;
        }

        public override void Prepare(string title)
        {
            base.Prepare();
            ScreenTitle = title;
            //EncryptedText = _rsaEncryption.Encrypt(title);
            //DecryptedText = _rsaEncryption.Decrypt(EncryptedText);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }
    }
}
