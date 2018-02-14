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

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.PreferencesView
{
    [Register ("PreferencesView")]
    partial class PreferencesView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnRedirectMyProfile { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitleScreen { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnRedirectMyProfile != null) {
                btnRedirectMyProfile.Dispose ();
                btnRedirectMyProfile = null;
            }

            if (lblTitleScreen != null) {
                lblTitleScreen.Dispose ();
                lblTitleScreen = null;
            }
        }
    }
}