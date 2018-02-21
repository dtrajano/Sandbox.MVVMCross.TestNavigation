using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.MVVMCross.TestNavigation.Core.Services.Implementations
{
    public class BaseService
    {
        protected  string GetUrlFromService(string service)
        {
            return Constants.BaseUrl + service.ToLower();
        }
    }
}
