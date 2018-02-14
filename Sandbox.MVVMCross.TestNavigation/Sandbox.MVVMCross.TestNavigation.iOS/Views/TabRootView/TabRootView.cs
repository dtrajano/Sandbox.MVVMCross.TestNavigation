using System;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.TabRootView
{
    [MvxFromStoryboard("TabRootView")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class TabRootView : MvxTabBarViewController<TabRootViewModel>
    {
        private bool _isPresentedFirstTime = true;

        //public TabRootView() { 
        //    ViewDidLoad();
        //}

        public TabRootView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (ViewModel != null && _isPresentedFirstTime)
            {
                _isPresentedFirstTime = false;

                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
            }
        }

        protected override void SetTitleAndTabBarItem(UIViewController viewController, MvxTabPresentationAttribute attribute)
        {
            // you can override this method to set title or iconName
            if (string.IsNullOrEmpty(attribute.TabName))
                attribute.TabName = "Tab 2";
            if (string.IsNullOrEmpty(attribute.TabIconName))
                attribute.TabIconName = "ic_tabbar_menu";

            base.SetTitleAndTabBarItem(viewController, attribute);
        }

        //    public override bool ShowChildView(UIViewController viewController)
        //    {
        //        var type = viewController.GetType();

        //        return type == typeof(ChildView)
        //            ? false
        //            : base.ShowChildView(viewController);
        //    }

        //    public override bool CloseChildViewModel(IMvxViewModel viewModel)
        //    {
        //        var type = viewModel.GetType();

        //        return type == typeof(ChildViewModel)
        //            ? false
        //            : base.CloseChildViewModel(viewModel);

        //}
    }
}

