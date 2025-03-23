using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.EmployeeV;
using System;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.EmployeeVM
{
    public class EmployeesViewModel : AListItemViewModel<Employee>
    {
        public EmployeesViewModel(IApiService<Employee> itemService, INavigationService navigationService, string title) : base(itemService, navigationService, title)
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddEmployeeView));

        public override async Task GoToDetailsPage(Employee item) 
            => await NavService.NavigateToAsync($"{nameof(EmployeeDetailsView)}?{nameof(EmployeeDetailViewModel.ItemId)}={item.EmployeeID}");
    }
}
