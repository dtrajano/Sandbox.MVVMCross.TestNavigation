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

            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem("Voltar", UIBarButtonItemStyle.Plain, null),true);

            var set = this.CreateBindingSet<MyProfileView, MyProfileViewModel>();
            set.Bind(lblTitleScreen).To(vm=>vm.ScreenTitle);
            this.AddBindings(new Dictionary<object,string>() {
                {NavigationItem.LeftBarButtonItem, "Voltar"}
            });
            set.Bind(NavigationItem.LeftBarButtonItem).To(vm=>vm.Close);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

