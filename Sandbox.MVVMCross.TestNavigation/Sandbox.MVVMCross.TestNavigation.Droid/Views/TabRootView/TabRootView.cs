
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Plugin.CurrentActivity;
using Plugin.Permissions;
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

            //NECESSARIO PARA PLUGIN DE GERENCIAMENTO DE PERMISSOES, CRIAR UMA ACTIVITY BASE
            CrossCurrentActivity.Current.Activity = this;
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            setupIconsTabBar();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            //NECESSARIO PARA PLUGIN DE GERENCIAMENTO DE PERMISSOES, CRIAR UMA ACTIVITY BASE
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
