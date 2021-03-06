﻿using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Sandbox.MVVMCross.TestNavigation.Core.Models;

namespace Sandbox.MVVMCross.TestNavigation.Core.ViewModels
{
    public class PreferencesViewModel : MvxViewModel<string>
    {

        public string ScreenTitle
        {
            get;
            set;
        }

        public MvxAsyncCommand redirectToMyProfile
        {
            //get { return new MvxAsyncCommand(async () => await _navigationService.Navigate<MyProfileViewModel, string>(""));  }
            //get
            //{
            //    return new MvxCommand(() => ShowViewModel<MyProfileViewModel>());
            //}
            get { return new MvxAsyncCommand(async () => await RedirectToMyProfile()); }
        }


        IMvxNavigationService _navigationService;

        public PreferencesViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Prepare(string title)
        {
            base.Prepare();
            ScreenTitle = title;
        }

        public async Task RedirectToMyProfile()
        {
            await _navigationService.Navigate<MyProfileViewModel>();
            //var result = await _navigationService.Navigate<MyProfileViewModel, string>();
            //Console.WriteLine("result: " + result);
            //Do something with the result MyReturnObject that you get back
        }
    }
}
