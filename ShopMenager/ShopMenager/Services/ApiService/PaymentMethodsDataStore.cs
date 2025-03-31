using ShopMenager.Services.ApiService.Abstract;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class PaymentMethodsDataStore : AListDataStore<PaymentMethods>
    {
        public PaymentMethodsDataStore()
        {
            //items = DependencyService.Get<OrderService>()
            //                         ()
            //                         .GetAwaiter()
            //                         .GetResult()
            //                         .ToList();

        }

        public override Task<bool> AddItemToService(PaymentMethods item)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteItemFromService(PaymentMethods item)
        {
            throw new NotImplementedException();
        }

        public override PaymentMethods Find(PaymentMethods item)
        {
            throw new NotImplementedException();
        }

        public override PaymentMethods Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Task Refresh()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UpdateItemInService(PaymentMethods item)
        {
            throw new NotImplementedException();
        }

        //public override async Task<bool> AddItemToService(CategoryDto item)
        //    => await DependencyService.Get<OrderService>()
        //                             .CategoryPOSTAsync(item)
        //                             .HandleRequest();

        //public override Task<bool> DeleteItemFromService(CategoryDto item)
        //    => DependencyService.Get<OrderService>()
        //                       .CategoryDELETEAsync(item.CategoryID)
        //                       .HandleRequest();

        //public override CategoryDto Find(CategoryDto item)
        //    => items.FirstOrDefault(c => c.CategoryID == item.CategoryID);

        //public override CategoryDto Find(int id)
        //    => items.FirstOrDefault(s => s.CategoryID == id);

        //public override async Task Refresh()
        //    => items = (await DependencyService.Get<OrderService>()
        //                                      .CategoryAllAsync())
        //                                      .ToList();

        //public override async Task<bool> UpdateItemInService(CategoryDto item)
        //    => await DependencyService.Get<OrderService>()
        //                             .CategoryPUTAsync(item.CategoryID, item)
        //                             .HandleRequest();
    }
}
}
