using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.Models;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class AddressViewModel : MvxViewModel<string, Address>
    {

        private readonly IMvxNavigationService _navigationService;
        private Address _address;

        public string ScreenTitle
        {
            get;
            set;
        }

        public string Rua
        {
            get { return _address.Rua; }
            set { _address.Rua = value; }
        }

        public string CEP
        {
            get { return _address.CEP; }
            set { _address.CEP = value; }
        }

        public int Numero
        {
            get { return _address.Numero; }
            set { _address.Numero = value; }
        }

        public MvxAsyncCommand goToClose
        {
            get { return new MvxAsyncCommand(async () => await CloseScreen()); }
        }

        public AddressViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _address = new Address();
        }

        public override void Prepare()
        {
            base.Prepare();
        }

        public override void Prepare(string screenTitle)
        {
            base.Prepare();
            ScreenTitle = screenTitle;
        }

        public async Task CloseScreen() {
            await _navigationService.Close<Address>(this, _address);
        }
    }

}
