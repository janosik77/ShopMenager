using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class PaymentDataStore : AListDataStore<PaymentDto>
    {
        public PaymentDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .PaymentAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(PaymentDto item)
            => await DependencyService.Get<OrderService>()
                                      .PaymentPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(PaymentDto item)
            => DependencyService.Get<OrderService>()
                                .PaymentDELETEAsync(item.PaymentID)
                                .HandleRequest();

        public override PaymentDto Find(PaymentDto item)
            => items.FirstOrDefault(p => p.PaymentID == item.PaymentID);

        public override PaymentDto Find(int id)
            => items.FirstOrDefault(p => p.PaymentID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .PaymentAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(PaymentDto item)
            => await DependencyService.Get<OrderService>()
                                      .PaymentPUTAsync(item.PaymentID, item)
                                      .HandleRequest();
    }
}
