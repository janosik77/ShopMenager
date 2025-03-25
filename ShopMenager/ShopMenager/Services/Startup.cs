using Microsoft.Extensions.DependencyInjection;
using System;
using ShopMenager.ViewModels;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.ViewModels.DiscountVM;
using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.EmployeeVM;
using ShopMenager.ViewModels.OrderitemsVM;
using ShopMenager.ViewModels.PaymentVM;
using ShopMenager.ViewModels.ProductVM;
using ShopMenager.ViewModels.ReviewsVM;
using ShopMenager.Services.ApiService;

namespace ShopMenager.Services
{
    public class Startup
    {
        public static IServiceProvider ConfigureService ()
        {
            var services = new ServiceCollection();

            // services
            services.AddSingleton<CategoriesViewModel>();
            services.AddSingleton<CustomersPageViewModel>();
            services.AddSingleton<DicountViewModel>();
            services.AddSingleton<EmployeesViewModel>();
            services.AddSingleton<HomePageViewModel>();
            services.AddSingleton<OrdersItemsViewModel>();
            services.AddSingleton<PaymentsViewModel>();
            services.AddSingleton<ProductViewModel>();
            services.AddSingleton<ReviewsViewModel>();
            services.AddTransient<AddCustomerViewModel>();
            services.AddSingleton<CustomerDetailViewModel>();

            //Rest api connection services           
            services.AddSingleton<IDataStore<Categories>, CategoryDataStore>();
            services.AddSingleton<IDataStore<Discounts>, DiscountDataStore>();
            services.AddSingleton<IDataStore<Employees>, EmployeeDataStore>();
            services.AddSingleton<IDataStore<OrderDetails>, OrderDetailItemDataStore>();
            services.AddSingleton<IDataStore<Orders>, OrderDataStore>();
            services.AddSingleton<IDataStore<Payments>, PaymentDataStore>();
            services.AddSingleton<IDataStore<Reviews>, ReviewDataStore>();
            services.AddSingleton<IDataStore<Customers>, CustomerDataStore>();
            services.AddSingleton<IDataStore<Products>, ProductDataStore>();

            services.AddSingleton<INavigationService, NavigationService>();
            return services.BuildServiceProvider();


        }
    }
}
