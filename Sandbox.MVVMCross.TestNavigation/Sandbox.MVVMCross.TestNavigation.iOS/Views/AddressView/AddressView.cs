using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox.MVVMCross.TestNavigation.iOS.Views
{
    [MvxFromStoryboard("AddressView")]
    [MvxChildPresentation]
    public partial class AddressView : MvxViewController
    {
        public AddressView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var set = this.CreateBindingSet<AddressView, AddressViewModel>();
            set.Bind(txtRua).To(vm=>vm.Rua);
            set.Bind(txtCep).To(vm => vm.CEP);
            set.Bind(txtNumero).To(vm => vm.Numero);
            set.Bind(btnVoltar).To(vm=>vm.goToClose);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

