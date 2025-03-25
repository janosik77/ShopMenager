using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderVM
{
    public class OrdersViewModel : AListItemViewModel<Orders>
    {
        public OrdersViewModel(IDataStore<Orders> itemService) : base(itemService, "Orders")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddOrderView));

        public override async Task GoToDetailsPage(Orders item)
        => await Shell.Current.GoToAsync($"{nameof(OrderDetailView)}?{nameof(OrderDetailViewModel.ItemId)}={item.OrderID}");
    }
}
