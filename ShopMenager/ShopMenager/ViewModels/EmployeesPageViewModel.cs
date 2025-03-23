using ShopMenager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.ViewModels
{
    public class EmployeesPageViewModel : BaseViewModel
    {
        public EmployeesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Employees";
        }
    }
}
