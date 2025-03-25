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
    public class PaymentDataStore : AListDataStore<Payments>
    {
        public PaymentDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .PaymentAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(Payments item)
            => await DependencyService.Get<OrderService>()
                                      .PaymentPOSTAsync(item)
                                      .HandleRequest();

        public override Task<bool> DeleteItemFromService(Payments item)
            => DependencyService.Get<OrderService>()
                                .PaymentDELETEAsync(item.PaymentID)
                                .HandleRequest();

        public override Payments Find(Payments item)
            => items.FirstOrDefault(p => p.PaymentID == item.PaymentID);

        public override Payments Find(int id)
            => items.FirstOrDefault(p => p.PaymentID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .PaymentAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(Payments item)
            => await DependencyService.Get<OrderService>()
                                      .PaymentPUTAsync(item.PaymentID, item)
                                      .HandleRequest();
    }
}
