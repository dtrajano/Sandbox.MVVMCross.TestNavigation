using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Sandbox.MVVMCross.TestNavigation.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")                
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Client")                
                .AsInterfaces()
                .RegisterAsLazySingleton();
                        
            RegisterCustomAppStart<AppStart>();
        }
    }
}
