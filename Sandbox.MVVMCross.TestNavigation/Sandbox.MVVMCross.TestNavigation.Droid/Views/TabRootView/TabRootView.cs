
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
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

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            setupIconsTabBar();
        }

        private void setupIconsTabBar()
        {
            var tabLayout = (TabLayout)FindViewById(Resource.Id.tabs);

            for (int i = 0; i < tabLayout.TabCount; i++)
            {
                if (i == 0)
                {
                    tabLayout.GetTabAt(0).SetIcon(Resource.Drawable.icn_home);
                }
                else if (i == 1)
                {
                    tabLayout.GetTabAt(1).SetIcon(Resource.Drawable.icn_minha_lider);
                }
                else
                {
                    tabLayout.GetTabAt(2).SetIcon(Resource.Drawable.icn_preferencias);
                }
            }
        }
    }
}
