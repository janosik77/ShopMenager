using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views;
using ShopMenager.Views.OrderItemsV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class OrdersItemsViewModel : AListItemViewModel<OrderDetailDto>
    {
        public OrdersItemsViewModel(IDataStore<OrderDetailDto> itemService) : base(itemService, " Order Items Details")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddOrderItemView));

        public override async Task GoToDetailsPage(OrderDetailDto item) { }
            //=> await NavService.NavigateToAsync($"{nameof(OrderItemDetailView)}?{nameof(OrderPozDetailPageViewModel.ItemId)}={item.OrderDetailsId}");
    }
}
