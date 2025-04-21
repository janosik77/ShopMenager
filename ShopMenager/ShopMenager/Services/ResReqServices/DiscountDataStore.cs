using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class DiscountDataStore : AListDataStore<Discounts>
    {
        public DiscountDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .DiscountAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(Discounts item)
            => await DependencyService.Get<OrderService>()
                                     .DiscountPOSTAsync(item)
                                     .HandleRequest();

        public override Task<bool> DeleteItemFromService(Discounts item)
            => DependencyService.Get<OrderService>()
                               .DiscountDELETEAsync(item.DiscountId)
                               .HandleRequest();

        public override Discounts Find(Discounts item)
            => items.FirstOrDefault(c => c.DiscountId == item.DiscountId);

        public override Discounts Find(int id)
            => items.FirstOrDefault(s => s.DiscountId == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .DiscountAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(Discounts item)
            => await DependencyService.Get<OrderService>()
                                     .DiscountPUTAsync(item.DiscountId, item)
                                     .HandleRequest();
    }

}
