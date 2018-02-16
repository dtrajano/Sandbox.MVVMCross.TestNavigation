
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{

    [MvxActivityPresentation]
    [Activity(Theme = "@style/MyTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class TabRootView : MvxAppCompatActivity<TabRootViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TabRootView);

            if (bundle == null)
            {
                ViewModel.ShowInitialViewModelsCommand.Execute();
            }
        }
    }
}
