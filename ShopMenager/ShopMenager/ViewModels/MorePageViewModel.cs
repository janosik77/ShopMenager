using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class MorePageViewModel : BaseViewModel
    {
        public MorePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "More";
        }
    }
}
