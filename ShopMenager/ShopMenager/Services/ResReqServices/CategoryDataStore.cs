using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class CategoryDataStore : AListDataStore<CategoryDto>
    {
        public CategoryDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .CategoryAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(CategoryDto item)
            => await DependencyService.Get<OrderService>()
                                     .CategoryPOSTAsync(item)
                                     .HandleRequest();

        public override Task<bool> DeleteItemFromService(CategoryDto item)
            => DependencyService.Get<OrderService>()
                               .CategoryDELETEAsync(item.CategoryID)
                               .HandleRequest();

        public override CategoryDto Find(CategoryDto item)
            => items.FirstOrDefault(c => c.CategoryID == item.CategoryID);

        public override CategoryDto Find(int id)
            => items.FirstOrDefault(s => s.CategoryID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .CategoryAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(CategoryDto item)
            => await DependencyService.Get<OrderService>()
                                     .CategoryPUTAsync(item.CategoryID, item)
                                     .HandleRequest();
    }
}
