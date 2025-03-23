using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views;
using ShopMenager.Views.OrderItemsV;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.OrderitemsVM
{
    public class OrdersItemsViewModel : AListItemViewModel<OrdersItemView>
    {
        public OrdersItemsViewModel(IApiService<OrdersItemView> itemService, INavigationService navigationService) : base(itemService, navigationService, " Order Items Details")
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddOrderItemView));

        public override async Task GoToDetailsPage(OrdersItemView item) { }
            //=> await NavService.NavigateToAsync($"{nameof(OrderItemDetailView)}?{nameof(OrderPozDetailPageViewModel.ItemId)}={item.OrderDetailsId}");
    }
}
