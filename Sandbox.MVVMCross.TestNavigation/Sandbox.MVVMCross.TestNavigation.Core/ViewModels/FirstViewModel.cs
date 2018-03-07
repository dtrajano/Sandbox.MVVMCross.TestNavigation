using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

using Sandbox.MVVMCross.TestNavigation.Core.Models;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;
using Sandbox.MVVMCross.TestNavigation.Core.Services.Interfaces;

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
        private readonly ITesteService _testeService;
        private readonly IPermissionManager _permissionManager;

        public IMvxAsyncCommand redirectToTabRoot
        {
            get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<TabRootViewModel>());  }
        }

        public IMvxAsyncCommand testeCallApi => new MvxAsyncCommand(
                    async () =>
                    {
                        Login login = new Login()
                        {
                            grant_type = "password",
                            password = "Rafael@123",
                            username = "rafael.cardoso@lideraviacao.com.br"
                        };

                        var token = await _testeService.Login(login);

                        Hello = $"Teste Chamada Web Api passou! Token: {token.access_token}";

                    });


        public FirstViewModel(ITesteService testeService, IMvxNavigationService navigationService, IPermissionManager permissionManager)
        {
            _testeService = testeService;
            _navigationService = navigationService;
            _permissionManager = permissionManager;

            //_permissionManager.RequestPermission(Permission.Location);
        }        
    }
}
