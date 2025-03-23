using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class PaymentsPageViewModel : BaseViewModel
    {
        public PaymentsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Payments";
        }
    }
}
