using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using Sandbox.MVVMCross.TestNavigation.Core.NativeServices.Contracts;
using Sandbox.MVVMCross.TestNavigation.Droid.NativeServices;
using Sandbox_MVVMCross_TestNavigation.Droid;

namespace Sandbox.MVVMCross.TestNavigation.Droid
{
    public class Setup : MvxAppCompatSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<IRSAEncryption>(new RSAEncryption());
            Mvx.RegisterSingleton<IPermissionManager>(new PermissionManager());
            base.InitializeFirstChance();
        }
    }
}
