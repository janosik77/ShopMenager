using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class ReviewDataStore : AListDataStore<Reviews>
    {
        public ReviewDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .ReviewAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(Reviews item)
            => await DependencyService.Get<OrderService>()
                                      .ReviewPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(Reviews item)
            => DependencyService.Get<OrderService>()
                                .ReviewDELETEAsync(item.ReviewID)
                                .HandleRequest();

        public override Reviews Find(Reviews item)
            => items.FirstOrDefault(r => r.ReviewID == item.ReviewID);

        public override Reviews Find(int id)
            => items.FirstOrDefault(r => r.ReviewID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .ReviewAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(Reviews item)
            => await DependencyService.Get<OrderService>()
                                      .ReviewPUTAsync(item.ReviewID, item)
                                      .HandleRequest();
    }
}
