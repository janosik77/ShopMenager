using ShopMenager.Services.ApiService.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class PaymentMethodsDataStore : AListDataStore<PaymentMethods>
    {
        public PaymentMethodsDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .PaymentMethodAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();

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

        public override async Task Refresh() => items = (await DependencyService.Get<OrderService>()
                                                  .PaymentMethodAllAsync())
                                                  .ToList();


        public override Task<bool> UpdateItemInService(PaymentMethods item)
        {
            throw new NotImplementedException();
        }
    }
}
