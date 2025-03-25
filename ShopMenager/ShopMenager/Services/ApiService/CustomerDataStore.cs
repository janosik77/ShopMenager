using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class CustomerDataStore : AListDataStore<Customers>
    {
        public CustomerDataStore()
        {
            items = DependencyService.Get<OrderService>().CustomerAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override async Task<bool> AddItemToService(Customers item) 
            => await DependencyService.Get<OrderService>().CustomerPOSTAsync(item).HandleRequest();
         

        public override Task<bool> DeleteItemFromService(Customers item)
            => DependencyService.Get<OrderService>().CustomerDELETEAsync(item.CustomerId).HandleRequest();

        public override Customers Find(Customers item)
            => items.Where((Customers c) => c.CustomerId == item.CustomerId).FirstOrDefault();

        public override Customers Find(int id)
            => items.FirstOrDefault(s => s.CustomerId == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>().CustomerAllAsync()).ToList();

        public override async Task<bool> UpdateItemInService(Customers item)
            => await DependencyService.Get<OrderService>().CustomerPUTAsync(item.CustomerId, item).HandleRequest();
    }
}
