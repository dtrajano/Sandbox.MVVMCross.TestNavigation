
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{
    [MvxFragmentPresentation(ActivityHostViewModelType = typeof(RootViewModel), FragmentContentId = Resource.Id.content_frame)]
    [Register(nameof(MyProfileView))]
    public class MyProfileView : MvxFragment<MyProfileViewModel>
    //public class MyProfileView : BaseView
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.MyProfileView, null);
            return view;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }


        //protected override int LayoutResource => Resource.Layout.MyProfileView;

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    //SupportActionBar.SetDisplayHomeAsUpEnabled(false);

        //    TextView lblTitleScreen = FindViewById<TextView>(Resource.Id.lblTitleScreen);

        //    var set = this.CreateBindingSet<MyProfileView, MyProfileViewModel>();
        //    set.Bind(lblTitleScreen).To(vm => vm.ScreenTitle);
        //    set.Apply();
        //}
    }
}
