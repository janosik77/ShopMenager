using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderVM
{
    public class OrdersViewModel : AListItemViewModel<OrderDto>
    {
        public OrdersViewModel(IDataStore<OrderDto> itemService) : base(itemService, "Orders")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddOrderView));

        public override async Task GoToDetailsPage(OrderDto item)
        => await Shell.Current.GoToAsync($"{nameof(OrderDetailView)}?{nameof(OrderDetailViewModel.ItemId)}={item.OrderID}");
    }
}
