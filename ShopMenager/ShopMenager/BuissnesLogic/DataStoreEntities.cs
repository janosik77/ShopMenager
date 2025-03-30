using ShopMenager.Helpers;
using ShopMenager.Services.ApiService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMenager.BuissnesLogic
{
    public static class DataStoreEntities
    {
        //Lista przechowująca produkty odzwierciedlające baze
        public static List<ProductDto> DataStoreProducts { get; set; }
        public static async Task<List<KeyValueItem>> GetCustomerKeyValueItemsAsync(IDataStore<CustomerDto> customerDataStore)
        {
            var customers = await customerDataStore.GetItemsAsync();
            var customersKeyValueItems = customers.Select(c => new KeyValueItem
            {
                Key = c.CustomerId,
                Value = $"{c.FirstName} {c.LastName}"
            }).ToList();

            return new List<KeyValueItem>(customersKeyValueItems);
        }

        public static async Task<List<KeyValueItem>> GetEmployeeKeyValueItemsAsync(IDataStore<EmployeeDto> employeeDataStore)
        {
            var employees = await employeeDataStore.GetItemsAsync();
            var employeeKeyValueItems = employees.Select(c => new KeyValueItem
            {
                Key = c.EmployeeID,
                Value = $"{c.FirstName} {c.LastName}"
            }).ToList();

            return new List<KeyValueItem>(employeeKeyValueItems);
        }

        public static async Task<List<KeyValueItem>> GetProductKeyValueItemsAsync(IDataStore<ProductDto> productDataStore)
        {
            var products = await productDataStore.GetItemsAsync();
            DataStoreProducts = products.ToList();
            var productKeyValueItems = products.Select(c => new KeyValueItem
            {
                Key = c.ProductID,
                Value = $"{c.ProductName} - ${c.Price}"
            }).ToList();

            return new List<KeyValueItem>(productKeyValueItems);
        }

        public static async Task<List<KeyValueItem>> GetDiscountKeyValueItemsAsync(IDataStore<Discounts> discountsDataStore)
        {
            var discount = await discountsDataStore.GetItemsAsync();
            var discountKeyValueItems = discount.Select(c => new KeyValueItem
            {
                Key = c.DiscountId,
                Value = c.DiscountName
            }).ToList();

            return new List<KeyValueItem>(discountKeyValueItems);
        }
    }
}
