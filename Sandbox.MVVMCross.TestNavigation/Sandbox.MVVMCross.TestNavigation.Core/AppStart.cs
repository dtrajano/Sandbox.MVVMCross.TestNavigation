using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.MVVMCross.TestNavigation.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public AppStart(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public void Start(object hint = null)
        {
            _mvxNavigationService.Navigate<FirstViewModel>();
        }
    }
}
