using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;
using Sandbox_MVVMCross_TestNavigation.iOS;
using Sandbox_MVVMCross_TestNavigation.iOS.NativeServices;
using UIKit;

namespace Sandbox.MVVMCross.TestNavigation.iOS
{
    public class Setup : MvxIosSetup
    {
        private MvxApplicationDelegate _appDelegate;
        private UIWindow _window;
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _appDelegate = applicationDelegate;
            _window = window;
        }

        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
            _appDelegate = applicationDelegate;
            _window = applicationDelegate.Window;
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            //return base.CreatePresenter();
            var presenter = new CustomBaseViewPresenter(_appDelegate, _window);
            Mvx.RegisterSingleton(presenter);
            return presenter;
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<IRSAEncryption>(new RSAEncryption());
            base.InitializeFirstChance();
        }
    }
}
