
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{
    [MvxActivityPresentation()]
    [Activity(Label = "AddressView")]
    public class AddressView : MvxAppCompatActivity<AddressViewModel>
    {
        protected Toolbar Toolbar { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddressView);
            // Create your application here

            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(true);
            }
        }

        public override bool OnSupportNavigateUp()
        {
            ViewModel.CEP = string.Empty;
            ViewModel.Rua = string.Empty;
            ViewModel.Numero = 0;
            ViewModel.goToClose.ExecuteAsync();
            //ViewModel.ScreenTitle
            return base.OnSupportNavigateUp();
        }


    }
}
