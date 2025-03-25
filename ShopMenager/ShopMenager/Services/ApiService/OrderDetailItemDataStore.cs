using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class OrderDetailItemDataStore : AListDataStore<OrderDetails>
    {
        public OrderDetailItemDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .OrderDetailsAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(OrderDetails item)
            => await DependencyService.Get<OrderService>()
                                      .OrderDetailsPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(OrderDetails item)
            => DependencyService.Get<OrderService>()
                                .OrderDetailsDELETEAsync(item.OrderDetailsId)
                                .HandleRequest();

        public override OrderDetails Find(OrderDetails item)
            => items.FirstOrDefault(od => od.OrderDetailsId == item.OrderDetailsId);

        public override OrderDetails Find(int id)
            => items.FirstOrDefault(od => od.OrderDetailsId == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .OrderDetailsAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(OrderDetails item)
            => await DependencyService.Get<OrderService>()
                                      .OrderDetailsPUTAsync(item.OrderDetailsId, item)
                                      .HandleRequest();
    }
}
