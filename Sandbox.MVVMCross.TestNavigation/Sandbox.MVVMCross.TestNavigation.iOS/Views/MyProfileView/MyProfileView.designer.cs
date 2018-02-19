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

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.MyProfileView
{
    [Register ("MyProfileView")]
    partial class MyProfileView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCep { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNumero { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRua { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitleScreen { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnAddress != null) {
                btnAddress.Dispose ();
                btnAddress = null;
            }

            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }

            if (lblCep != null) {
                lblCep.Dispose ();
                lblCep = null;
            }

            if (lblNumero != null) {
                lblNumero.Dispose ();
                lblNumero = null;
            }

            if (lblRua != null) {
                lblRua.Dispose ();
                lblRua = null;
            }

            if (lblTitleScreen != null) {
                lblTitleScreen.Dispose ();
                lblTitleScreen = null;
            }
        }
    }
}