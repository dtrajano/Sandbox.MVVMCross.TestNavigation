using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.HomeView
{
    [MvxFromStoryboard("HomeView")]
    [MvxTabPresentation(WrapInNavigationController = true, TabIconName = "home", TabName = "Home")]
    public partial class HomeView : MvxViewController<HomeViewModel>
    {
        public HomeView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(lblTitleScreen).To(vm => vm.ScreenTitle);
            set.Bind(btnRedirectFirstOption).To(vm=>vm.redirectFirstOption);
            set.Apply();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

