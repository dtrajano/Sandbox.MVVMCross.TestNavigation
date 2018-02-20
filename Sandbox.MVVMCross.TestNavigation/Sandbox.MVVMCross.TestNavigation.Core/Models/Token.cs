using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.MVVMCross.TestNavigation.Core.Models
{
    public class Token
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string expires_in { get; set; }
    }
}
