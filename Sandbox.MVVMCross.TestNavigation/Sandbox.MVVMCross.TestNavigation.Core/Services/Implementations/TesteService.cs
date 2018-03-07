using Sandbox.MVVMCross.TestNavigation.Core.Models;
using Sandbox.MVVMCross.TestNavigation.Core.Rest.Interfaces;
using Sandbox.MVVMCross.TestNavigation.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.MVVMCross.TestNavigation.Core.Services.Implementations
{
    public class TesteService : BaseService, ITesteService
    {
        private readonly IRestClient _restClient;

        public TesteService(IRestClient restiClient)
        {
            _restClient = restiClient;
        }

        public async Task<Token> Login(Login login)
        {
            var url = GetUrlFromService(nameof(TesteService));

            return await _restClient.MakeApiCall<Token>(url,
                                                        HttpMethod.Post,
                                                        login);
        }
    }
}
