using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class SupplierPageViewModel : BaseViewModel
    {
        public SupplierPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Suppliers";
        }
    }
}
