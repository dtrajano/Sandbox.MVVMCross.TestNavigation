using Sandbox.MVVMCross.TestNavigation.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.MVVMCross.TestNavigation.Core.Services.Interfaces
{
    public interface ITesteService
    {
        Task<Token> Login(Login login);
    }
}
