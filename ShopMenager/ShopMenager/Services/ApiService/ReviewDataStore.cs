using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class ReviewDataStore : AListDataStore<ReviewsDto>
    {
        public ReviewDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .ReviewAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(ReviewsDto item)
            => await DependencyService.Get<OrderService>()
                                      .ReviewPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(ReviewsDto item)
            => DependencyService.Get<OrderService>()
                                .ReviewDELETEAsync(item.ReviewID)
                                .HandleRequest();

        public override ReviewsDto Find(ReviewsDto item)
            => items.FirstOrDefault(r => r.ReviewID == item.ReviewID);

        public override ReviewsDto Find(int id)
            => items.FirstOrDefault(r => r.ReviewID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .ReviewAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(ReviewsDto item)
            => await DependencyService.Get<OrderService>()
                                      .ReviewPUTAsync(item.ReviewID, item)
                                      .HandleRequest();
    }
}
