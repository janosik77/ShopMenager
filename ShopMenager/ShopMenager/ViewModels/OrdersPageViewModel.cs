using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class OrdersPageViewModel : BaseViewModel
    {
        public OrdersPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Orders";
        }
    }
}
