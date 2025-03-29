using ShopMenager.Helpers;
using ShopMenager.Services.ApiService.Abstract;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShopMenager.Services.ApiService
{
    public class EmployeeDataStore : AListDataStore<EmployeeDto>
    {
        public EmployeeDataStore()
        {
            items = DependencyService.Get<OrderService>()
                                     .EmployeeAllAsync()
                                     .GetAwaiter()
                                     .GetResult()
                                     .ToList();
        }

        public override async Task<bool> AddItemToService(EmployeeDto item)
            => await DependencyService.Get<OrderService>()
                                     .EmployeePOSTAsync(item)
                                     .HandleRequest();

        public override Task<bool> DeleteItemFromService(EmployeeDto item)
            => DependencyService.Get<OrderService>()
                               .EmployeeDELETEAsync(item.EmployeeID)
                               .HandleRequest();

        public override EmployeeDto Find(EmployeeDto item)
            => items.FirstOrDefault(c => c.EmployeeID == item.EmployeeID);

        public override EmployeeDto Find(int id)
            => items.FirstOrDefault(s => s.EmployeeID == id);

        public override async Task Refresh()
            => items = (await DependencyService.Get<OrderService>()
                                              .EmployeeAllAsync())
                                              .ToList();

        public override async Task<bool> UpdateItemInService(EmployeeDto item)
            => await DependencyService.Get<OrderService>()
                                     .EmployeePUTAsync(item.EmployeeID, item)
                                     .HandleRequest();
    }

}
