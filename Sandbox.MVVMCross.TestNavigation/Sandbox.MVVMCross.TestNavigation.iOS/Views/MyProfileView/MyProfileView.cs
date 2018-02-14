using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.MyProfileView
{
    [MvxFromStoryboard("MyProfileView")]
    public partial class MyProfileView : MvxViewController
    {
        public MyProfileView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Voltar", UIBarButtonItemStyle.Plain, null),true);
            var set = this.CreateBindingSet<MyProfileView, MyProfileViewModel>();
            set.Bind(lblTitleScreen).To(vm=>vm.ScreenTitle);
            set.Bind(btnClose).To(vm=>vm.Close);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

