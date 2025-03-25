using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class CategoryDataStore : AListDataStore<Categories>
    {
        public CategoryDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .CategoryAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(Categories item)
            => await DependencyService.Get<OrderService>()
                                     .CategoryPOSTAsync(item)
                                     .HandleRequest();

        public override Task<bool> DeleteItemFromService(Categories item)
            => DependencyService.Get<OrderService>()
                               .CategoryDELETEAsync(item.CategoryId)
                               .HandleRequest();

        public override Categories Find(Categories item)
            => items.FirstOrDefault(c => c.CategoryId == item.CategoryId);

        public override Categories Find(int id)
            => items.FirstOrDefault(s => s.CategoryId == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .CategoryAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(Categories item)
            => await DependencyService.Get<OrderService>()
                                     .CategoryPUTAsync(item.CategoryId, item)
                                     .HandleRequest();
    }
}
