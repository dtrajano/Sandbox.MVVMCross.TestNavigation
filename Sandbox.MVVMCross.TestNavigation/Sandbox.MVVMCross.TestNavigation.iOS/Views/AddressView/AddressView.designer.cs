// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Sandbox.MVVMCross.TestNavigation.iOS.Views
{
    [Register ("AddressView")]
    partial class AddressView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnVoltar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtCep { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtNumero { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtRua { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnVoltar != null) {
                btnVoltar.Dispose ();
                btnVoltar = null;
            }

            if (txtCep != null) {
                txtCep.Dispose ();
                txtCep = null;
            }

            if (txtNumero != null) {
                txtNumero.Dispose ();
                txtNumero = null;
            }

            if (txtRua != null) {
                txtRua.Dispose ();
                txtRua = null;
            }
        }
    }
}