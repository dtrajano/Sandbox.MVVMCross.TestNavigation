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

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.MyMenuView
{
    [Register ("MyMenuView")]
    partial class MyMenuView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitleScreen { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblTitleScreen != null) {
                lblTitleScreen.Dispose ();
                lblTitleScreen = null;
            }
        }
    }
}