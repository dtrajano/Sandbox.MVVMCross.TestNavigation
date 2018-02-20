using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.MVVMCross.TestNavigation.Core.Rest.Interfaces
{
    public interface IRestClient
    {
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null)
                        where TResult : class;
    }
}
