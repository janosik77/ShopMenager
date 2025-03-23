using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShopMenager.ViewModels
{
    public class CategoriesPageViewModel : BaseViewModel
    {
        public CategoriesPageViewModel(INavigationService navigationService) : base(navigationService) 
        {
            Title = "Categories";
        }
    }
}
