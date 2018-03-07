using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Plugin.Permissions.Abstractions;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IRSAEncryption _rsaEncryption;
        private readonly IPermissionManager _permissionManager;

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

        private bool _statusPermissao;
        public bool StatusPermissaoNotificacao
        {
            get { return _statusPermissao; }
            set 
            {
                _statusPermissao = value;
                RaisePropertyChanged();
            }
        }

        public IMvxAsyncCommand redirectFirstOption
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<FirstViewModel>()); }
        }

        public IMvxAsyncCommand requestPermissionLocation
        {
            get { return new MvxAsyncCommand(async () => await SolicitarPermissaoGeolocalizacao()); }
        }

        public HomeViewModel(IMvxNavigationService navigationService, IRSAEncryption rsaEncryption, IPermissionManager permissionManager)
        {
            _navigationService = navigationService;
            _rsaEncryption = rsaEncryption;
            _permissionManager = permissionManager;
        }

        public override async void Prepare(string title)
        {
            base.Prepare();
            ScreenTitle = title;
            var result = await _permissionManager.CheckPermissionStatus(Permission.Location);
            StatusPermissaoNotificacao = result == PermissionStatus.Granted ? true : false;
            //EncryptedText = _rsaEncryption.Encrypt(title);
            //DecryptedText = _rsaEncryption.Decrypt(EncryptedText);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
        }

        private async Task SolicitarPermissaoGeolocalizacao()
        {
            var result = await _permissionManager.RequestPermission(Permission.Location);
            StatusPermissaoNotificacao = result == PermissionStatus.Granted ? true : false;
        }
    }
}
