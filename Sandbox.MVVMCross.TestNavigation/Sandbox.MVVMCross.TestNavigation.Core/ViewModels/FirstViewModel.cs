using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.Models;
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
                            password = "Max_123",
                            username = "maximilian.silva@teste.com.br"
                        };

                        var token = await _testeService.Login(login);

                        Hello = $"Teste Chamada Web Api passou! Token: {token.access_token}";

                    });

        //TODO: Erro na Ingeção de dependência
        public FirstViewModel(ITesteService testeService, IMvxNavigationService navigationService)
        {
            _testeService = testeService;
            _navigationService = navigationService;
        }        
    }
}
