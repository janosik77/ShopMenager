﻿using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Home";
        }
    }
}
