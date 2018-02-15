using System;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using Sandbox.MVVMCross.TestNavigation.Core.Hints;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox.MVVMCross.TestNavigation.iOS
{
    public class CustomBaseViewPresenter : MvxIosViewPresenter
    {
        public CustomBaseViewPresenter(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        public override void Show(MvvmCross.Core.ViewModels.MvxViewModelRequest request)
        {
            base.Show(request);



        }

        public override void ChangePresentation(MvvmCross.Core.ViewModels.MvxPresentationHint hint)
        {
            base.ChangePresentation(hint);

            if (hint is ClearNavBackStackHint)
            {
                //((TabRootViewModel)((ClearNavBackStackHint)hint)._actualViewModel).ShowTabRootCommand.ExecuteAsync(false);


                int tabId = ((ClearNavBackStackHint)hint)._tabId - 1;

                var controller = _window.RootViewController.ChildViewControllers[tabId];

                if (controller.ChildViewControllers.Length > 0)
                {
                    if (controller.ChildViewControllers[0].NavigationController != null)
                    {
                        controller.ChildViewControllers[0].NavigationController.PopViewController(false);
                    }
                }

                //int tabId = 2;
            }
        }
    }
}
