using ShopMenager.Services.ApiService;
using System.Threading.Tasks;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.CustomerV;
using Xamarin.Forms;


namespace ShopMenager.ViewModels.CustomerVM
{
    public class CustomersPageViewModel : AListItemViewModel<CustomerDto>
    {
        public CustomersPageViewModel(IDataStore<CustomerDto> itemService) : base(itemService, "Customers")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddCustomerView));

        public override async Task GoToDetailsPage(CustomerDto item) 
            => await Shell.Current
            .GoToAsync($"{nameof(CustomerDetailsView)}?{nameof(CustomerDetailViewModel.ItemId)}={item.CustomerId}");
    }
}
