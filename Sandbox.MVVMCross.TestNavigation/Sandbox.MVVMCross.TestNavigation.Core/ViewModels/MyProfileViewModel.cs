using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.Hints;
using Sandbox.MVVMCross.TestNavigation.Core.Models;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class MyProfileViewModel : MvxViewModel<string, string>
    {

        public string ScreenTitle
        {
            get { return "My Profile"; }
        }

        public IMvxAsyncCommand Close
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Close(this, "teste retorno profile")); }
        }

        public MvxAsyncCommand goToAddress
        {
            get { return new MvxAsyncCommand(async () => await RedirectToAddress()); }
        }

        private Address _address;
        public Address currentAddress
        {
            get => _address;
            set
            {
                _address = value;
                RaisePropertyChanged();
            }
        }
        private string _rua;
        public string Rua
        {
            get => _rua;
            set
            {
                _rua = value;
                RaisePropertyChanged();
            }
        }

        private string _cep;
        public string CEP
        {
            get => _cep;
            set
            {
                _cep = value;
                RaisePropertyChanged();
            }
        }

        private int _numero;
        public int Numero
        {
            get => _numero;
            set
            {
                _numero = value;
                RaisePropertyChanged();
            }
        }

        public IMvxAsyncCommand ShowRootCommand { get; private set; }


        IMvxNavigationService _navigationService;

        public MyProfileViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            currentAddress = new Address();
            ShowRootCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());
        }

        public override void Prepare(string message)
        {
            base.Prepare();
        }       

        //public override void ViewDestroy()
        //{
        //    base.ViewDestroy();
        //}

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

        public async Task RedirectToAddress()
        {
            var result = await _navigationService.Navigate<AddressViewModel, Address>();
            if(result == null) {
                result = new Address();
            }
            currentAddress = result as Address;
            this.Rua = currentAddress.Rua;
            this.CEP = currentAddress.CEP;
            this.Numero = currentAddress.Numero;
        }

        //public override void Start()
        //{
        //    base.Start();
        //}
    }
}
