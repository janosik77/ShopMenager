using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{

    public class ProductDataStore : AListDataStore<Products>
    {
        public ProductDataStore()
        {
            items = DependencyService.Get<OrderService>().ProductAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override async Task<bool> AddItemToService(Products item)
            => await DependencyService.Get<OrderService>().ProductPOSTAsync(item).HandleRequest();


        public override Task<bool> DeleteItemFromService(Products item)
            => DependencyService.Get<OrderService>().ProductDELETEAsync(item.ProductID).HandleRequest();

        public override Products Find(Products item)
            => items.Where((Products c) => c.ProductID == item.ProductID).FirstOrDefault();

        public override Products Find(int id)
            => items.FirstOrDefault(s => s.ProductID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>().ProductAllAsync()).ToList();

        public override async Task<bool> UpdateItemInService(Products item)
            => await DependencyService.Get<OrderService>().ProductPUTAsync(item.ProductID, item).HandleRequest();
    }
}
