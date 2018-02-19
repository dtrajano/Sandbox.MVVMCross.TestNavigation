
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{
    [MvxActivityPresentation()]
    [Activity(Label = "My")]
    public class MyProfileView : MvxAppCompatActivity<MyProfileViewModel>
    {
        //protected override int LayoutResource => Resource.Layout.FirstView;

        protected Toolbar Toolbar { get; set; }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SetContentView(Resource.Layout.MyProfileView);

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }

            Android.Widget.TextView lblTitleScreen = FindViewById<Android.Widget.TextView>(Resource.Id.lblTitleScreen);

            var set = this.CreateBindingSet<MyProfileView, MyProfileViewModel>();
            set.Bind(lblTitleScreen).To(vm => vm.ScreenTitle);
            set.Apply();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_top, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnSupportNavigateUp()
        {
            ViewModel.Close.Execute();
            //ViewModel.ScreenTitle
            return base.OnSupportNavigateUp();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //return base.OnOptionsItemSelected(item);
            var set = this.CreateBindingSet<MyProfileView, MyProfileViewModel>();
            switch (item.ItemId)
            {

                case Resource.Id.menu_save:
                    ViewModel.Close.Execute();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
