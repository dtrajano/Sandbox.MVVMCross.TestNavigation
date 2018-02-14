using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.PreferencesView
{
    [MvxFromStoryboard("PreferencesView")]
    [MvxTabPresentation(TabIconName = "home", TabName = "Preferences")]
    public partial class PreferencesView : MvxViewController<PreferencesViewModel>
    {
        public PreferencesView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var set = this.CreateBindingSet<PreferencesView, PreferencesViewModel>();
            set.Bind(lblTitleScreen).To(vm => vm.ScreenTitle);
            set.Bind(btnRedirectMyProfile).To(vm => vm.redirectToMyProfile);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

