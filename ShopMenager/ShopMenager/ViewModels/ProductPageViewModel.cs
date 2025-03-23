using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class ProductPageViewModel : BaseViewModel
    {
        public ProductPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Products";
        }
    }
}
