using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;
using UIKit;

namespace Sandbox_MVVMCross_TestNavigation.iOS.Views.TabRootView
{
    [MvxFromStoryboard("TabRootView")]
    [MvxRootPresentation(WrapInNavigationController = false)]
    public partial class TabRootView : MvxTabBarViewController<TabRootViewModel>
    {
        private bool _isPresentedFirstTime = true;


        public TabRootView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (ViewModel != null && _isPresentedFirstTime)
            {
                _isPresentedFirstTime = false;

                ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);

                //var set = this.CreateBindingSet<TabRootView, TabRootViewModel>();
                //set.Bind(this).For(v => v.SelectedIndex).To(vm => vm.ItemIndex);
                //set.Bind(this.TabBarController).For(c=>c.SelectedIndex).To(vm => vm.ItemIndex);
                //set.Apply();
            }

            //NavigationController.NavigationBarHidden = true;
        }

        protected override void SetTitleAndTabBarItem(UIViewController viewController, MvxTabPresentationAttribute attribute)
        {
            // you can override this method to set title or iconName
            if (string.IsNullOrEmpty(attribute.TabName))
                attribute.TabName = "Tab 2";
            //if (string.IsNullOrEmpty(attribute.TabIconName))
                //attribute.TabIconName = "ic_tabbar_menu";
            this.TabBar.BarTintColor = UIColor.FromRGB(3,90,91);
            this.TabBar.TintColor = UIColor.White;
            this.TabBar.SelectedImageTintColor = UIColor.Red;
            this.TabBar.UnselectedItemTintColor = UIColor.White;

            base.SetTitleAndTabBarItem(viewController, attribute);
        }

        public override void ShowTabView(UIViewController viewController, MvxTabPresentationAttribute attribute)
        {
            base.ShowTabView(viewController, attribute);
        }

        //DISPARADO SEMPRE QUE UMA VIEW DE SEGUNDO NIVEL ABRE E VOLTA PARA VIEW PRINCIPAL DA TAB
        public override bool ShowChildView(UIViewController viewController)
        {
            return base.ShowChildView(viewController);
        }

        //DISPARADO SEMPRE QUE UMA VIEW DE SEGUNDO NIVEL FECHA E VOLTA PARA VIEW PRINCIPAL DA TAB
        public override bool CloseChildViewModel(MvvmCross.Core.ViewModels.IMvxViewModel viewModel)
        {
            return base.CloseChildViewModel(viewModel);
        }

        public override nint SelectedIndex
        {
            get
            {
                return base.SelectedIndex;
            }
            set
            {
                base.SelectedIndex = value;
            }
        }

        public override void Select(Foundation.NSObject sender)
        {
            base.Select(sender);
        }

        public override void DidChangeValue(string forKey)
        {
            base.DidChangeValue(forKey);
        }

        public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
        }

        public override UIViewController SelectedViewController
        {
            get
            {
                return base.SelectedViewController;
            }
            set
            {
                base.SelectedViewController = value;
            }
        }

        //DISPARADO SEMPRE QUE É FEITO UMA TROCA DE TAB
        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            int tabPosition = Convert.ToInt32(item.Tag);

            ViewModel.ItemIndex = tabPosition;
            ViewModel.clearStackPreferencesTabCommand.Execute(null);
        }
    }
}

