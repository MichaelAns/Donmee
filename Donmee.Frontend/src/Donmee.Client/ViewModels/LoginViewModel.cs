﻿using System.Diagnostics;
using Donmee.Client.Services.Navigation;
using Donmee.Client.ViewModels.Base;

namespace Donmee.Client.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        [RelayCommand]
        private async Task SignInAsync()
        {
            try
            {
                // TODO : Auth
            }
            catch (Exception exc)
            {
                Debug.WriteLine($"[SignIn] Error signing in: {exc}");
            }
            await NavigationService.NavigateToAsync("//Main/Wishes/CommonWishes");
        }
    }
}