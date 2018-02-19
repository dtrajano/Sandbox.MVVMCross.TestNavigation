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

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.HomeView
{
    [Register ("HomeView")]
    partial class HomeView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRedirectFirstOption { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDecrypted { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblEncrypted { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitleScreen { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnRedirectFirstOption != null) {
                btnRedirectFirstOption.Dispose ();
                btnRedirectFirstOption = null;
            }

            if (lblDecrypted != null) {
                lblDecrypted.Dispose ();
                lblDecrypted = null;
            }

            if (lblEncrypted != null) {
                lblEncrypted.Dispose ();
                lblEncrypted = null;
            }

            if (lblTitleScreen != null) {
                lblTitleScreen.Dispose ();
                lblTitleScreen = null;
            }
        }
    }
}