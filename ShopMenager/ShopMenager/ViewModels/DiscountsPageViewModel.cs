using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class DiscountsPageViewModel : BaseViewModel
    {
        public DiscountsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Discounts";
        }
    }
}
