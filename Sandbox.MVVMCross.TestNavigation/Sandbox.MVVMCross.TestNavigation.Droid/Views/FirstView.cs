using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : BaseView<FirstView>
    {
        protected override int LayoutResource => Resource.Layout.FirstView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);

            Button btnRedirect = FindViewById<Button>(Resource.Id.btnRedirect);
            Button btnTesteCallApi = FindViewById<Button>(Resource.Id.btnTesteCallApi);

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(btnRedirect).To(vm=>vm.redirectToTabRoot);
            set.Bind(btnTesteCallApi).To(vm => vm.testeCallApi);            
            set.Apply();
        }
    }
}
