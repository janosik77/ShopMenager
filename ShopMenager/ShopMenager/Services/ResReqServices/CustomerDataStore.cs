using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class CustomerDataStore : AListDataStore<CustomerDto>
    {
        public CustomerDataStore()
        {
            items = DependencyService.Get<OrderService>().CustomersAllAsync().GetAwaiter().GetResult().ToList();
        }

        public override async Task<bool> AddItemToService(CustomerDto item) 
            => await DependencyService.Get<OrderService>().CustomersPOSTAsync(item).HandleRequest();
         

        public override Task<bool> DeleteItemFromService(CustomerDto item)
            => DependencyService.Get<OrderService>().CustomersDELETEAsync(item.CustomerId).HandleRequest();

        public override CustomerDto Find(CustomerDto item)
            => items.Where((CustomerDto c) => c.CustomerId == item.CustomerId).FirstOrDefault();

        public override CustomerDto Find(int id)
            => items.FirstOrDefault(s => s.CustomerId == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>().CustomersAllAsync()).ToList();

        public override async Task<bool> UpdateItemInService(CustomerDto item)
            => await DependencyService.Get<OrderService>().CustomersPUTAsync(item.CustomerId, item).HandleRequest();
    }
}
