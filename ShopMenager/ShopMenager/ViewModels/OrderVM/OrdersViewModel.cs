using ShopMenager.Models;
using ShopMenager.Services;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using ShopMenager.Views.OrderV;
using System.Threading.Tasks;

namespace ShopMenager.ViewModels.OrderVM
{
    public class OrdersViewModel : AListItemViewModel<Order>
    {
        public OrdersViewModel(IApiService<Order> itemService, INavigationService navigationService) : base(itemService, navigationService, "Orders")
        {
        }

        public override Task GoToAddPage() => NavService.NavigateToAsync(nameof(AddOrderView));

        public override async Task GoToDetailsPage(Order item)
        => await NavService.NavigateToAsync($"{nameof(OrderDetailView)}?{nameof(OrderDetailViewModel.ItemId)}={item.OrderID}");
    }
}
