using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class OrderDataStore : AListDataStore<OrderDto>
    {
        public OrderDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .OrdersAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(OrderDto item)
            => await DependencyService.Get<OrderService>()
                                      .OrdersPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(OrderDto item)
            => DependencyService.Get<OrderService>()
                                .OrdersDELETEAsync(item.OrderID)
                                .HandleRequest();

        public override OrderDto Find(OrderDto item)
            => items.FirstOrDefault(o => o.OrderID == item.OrderID);

        public override OrderDto Find(int id)
            => items.FirstOrDefault(o => o.OrderID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .OrdersAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(OrderDto item)
            => await DependencyService.Get<OrderService>()
                                      .OrdersPUTAsync(item.OrderID, item)
                                      .HandleRequest();
    }
}
