using System;
using MvvmCross.Core.ViewModels;

namespace Sandbox.MVVMCross.TestNavigation.Core.Hints
{
    public class ClearNavBackStackHint : MvxPresentationHint
    {
        public IMvxViewModel _actualViewModel;
        public int _tabId;

        public ClearNavBackStackHint() { }

        public ClearNavBackStackHint(Type viewModel)
        {
            ViewModel = viewModel;
        }

        public ClearNavBackStackHint(IMvxViewModel viewModel)
        {
            _actualViewModel = viewModel;
        }

        public ClearNavBackStackHint(int tabId)
        {
            this._tabId = tabId;
        }

        public Type ViewModel { get; private set; }
    }
}
