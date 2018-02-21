using ModernHttpClient;
using MvvmCross.Platform.Platform;
using Newtonsoft.Json.Linq;
using Sandbox.MVVMCross.TestNavigation.Core.ExtensionMethods;
using Sandbox.MVVMCross.TestNavigation.Core.Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.MVVMCross.TestNavigation.Core.Rest.Implementations
{
    public class RestClient : IRestClient
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public RestClient()
        {
            _jsonConverter = new MvvmCross.Plugins.Json.MvxJsonConverter();
        }

        public async Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null) where TResult : class
        {
            url = url.Replace("http://", "https://");

            using (var httpClient = new HttpClient(new NativeMessageHandler()))
            {               
                using (var request = new HttpRequestMessage { RequestUri = new Uri(url), Method = method})
                {
                    // add content
                    if (method != HttpMethod.Get)
                    {
                        var formUrlEncodedContent = new FormUrlEncodedContent(data.ToKeyValue());
                        
                        var parameters = await formUrlEncodedContent.ReadAsStringAsync();
                        request.Content = new StringContent(parameters, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = new HttpResponseMessage();
                    try
                    {
                        response = await httpClient.SendAsync(request).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        var a = ex;
                        // log error
                    }

                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // deserialize content
                    return _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                }
            }
        }
    }
}
