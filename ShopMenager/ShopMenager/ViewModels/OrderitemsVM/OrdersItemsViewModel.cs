using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views;
using ShopMenager.Views.OrderItemsV;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class OrdersItemsViewModel : AListItemViewModel<OrdersItemView>
    {
        public OrdersItemsViewModel(IDataStore<OrdersItemView> itemService) : base(itemService, " Order Items Details")
        {
        }

        public override Task GoToAddPage() => Shell.Current.GoToAsync(nameof(AddOrderItemView));

        public override async Task GoToDetailsPage(OrdersItemView item) { }
            //=> await NavService.NavigateToAsync($"{nameof(OrderItemDetailView)}?{nameof(OrderPozDetailPageViewModel.ItemId)}={item.OrderDetailsId}");
    }
}
