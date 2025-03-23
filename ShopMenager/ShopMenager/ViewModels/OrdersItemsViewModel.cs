using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class OrdersItemsViewModel : BaseViewModel
    {
        public OrdersItemsViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Order Positions";
        }
    }
}
