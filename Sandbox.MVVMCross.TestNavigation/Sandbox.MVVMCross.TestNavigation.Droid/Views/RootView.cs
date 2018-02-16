using System;
using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{

    [MvxActivityPresentation]
    [Activity(Theme = "@style/MyTheme")]
    public class RootView : MvxAppCompatActivity<RootViewModel>
    {
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RootView);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}
