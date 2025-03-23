using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.CustomerV;


namespace ShopMenager.ViewModels.CustomerVM
{
    public class CustomersPageViewModel : AListItemViewModel<Customer>
    {
        public CustomersPageViewModel(IApiService<Customer> itemService, INavigationService navigationService) : base(itemService, navigationService, "Customers")
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddCustomerView));

        public override async Task GoToDetailsPage(Customer item) 
            => await NavService.NavigateToAsync($"{nameof(CustomerDetailsView)}?{nameof(CustomerDetailViewModel.ItemId)}={item.CustomerId}");
    }
}
