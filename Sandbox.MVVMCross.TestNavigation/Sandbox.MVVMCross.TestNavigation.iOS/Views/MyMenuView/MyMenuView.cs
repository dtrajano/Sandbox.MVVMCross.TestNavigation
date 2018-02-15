using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.MyMenuView
{
    [MvxFromStoryboard("MyMenuView")]
    [MvxTabPresentation(WrapInNavigationController = false, TabIconName = "ic_tabbar_menu", TabName = "My Menu")]
    public partial class MyMenuView : MvxViewController<MyMenuViewModel>
    {
        public MyMenuView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<MyMenuView, MyMenuViewModel>();
            set.Bind(lblTitleScreen).To(vm => vm.ScreenTitle);
            set.Apply();
        }
            
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

