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
using ShopMenager.ViewModels.OrderVM;

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
            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<PaymentsViewModel>();
            services.AddSingleton<ProductViewModel>();
            services.AddSingleton<ReviewsViewModel>();

            //edit models
            services.AddTransient<EditCustomerViewModel>();
            services.AddTransient<EditEmployeeViewModel>();
            services.AddTransient<EditProductViewModel>();
            services.AddTransient<EditCategoryViewModel>();
            services.AddTransient<EditDiscountsViewModel>();
            services.AddTransient<EditOrderViewModel>();
            services.AddTransient<EditPaymentViewModel>();

            //add models services
            services.AddTransient<AddCustomerViewModel>();
            services.AddTransient<AddEmployeeViewModel>();
            services.AddTransient<AddproductViewModel>();
            services.AddTransient<AddCategoryViewModel>();
            services.AddTransient<AddDiscountsViewModel>();
            services.AddTransient<AddOrderViewModel>();
            services.AddTransient<AddpaymentViewModel>();

            //details models
            services.AddTransient<DiscountsDetailsViewModel>();
            services.AddTransient<EmployeeDetailViewModel>();
            services.AddTransient<OrderDetailViewModel>();
            services.AddTransient<PaymentDetailViewModel>();
            services.AddTransient<ProductDetailViewModel>();
            services.AddTransient<ReviewDetailViewModel>();
            services.AddTransient<CategoryDetailViewModel>();
            services.AddTransient<CustomerDetailViewModel>();


            //Rest api connection services           
            services.AddSingleton<IDataStore<CategoryDto>, CategoryDataStore>();
            services.AddSingleton<IDataStore<Discounts>, DiscountDataStore>();
            services.AddSingleton<IDataStore<EmployeeDto>, EmployeeDataStore>();
            services.AddSingleton<IDataStore<OrderDetails>, OrderDetailItemDataStore>();
            services.AddSingleton<IDataStore<OrderDto>, OrderDataStore>();
            services.AddSingleton<IDataStore<PaymentDto>, PaymentDataStore>();
            services.AddSingleton<IDataStore<ReviewsDto>, ReviewDataStore>();
            services.AddSingleton<IDataStore<CustomerDto>, CustomerDataStore>();
            services.AddSingleton<IDataStore<ProductDto>, ProductDataStore>();
            services.AddSingleton<IDataStore<PaymentMethods>, PaymentMethodsDataStore>();
            services.AddSingleton<IDataStore<HomePageDto>, HomePageDataStore>();

            services.AddSingleton<INavigationService, NavigationService>();
            return services.BuildServiceProvider();


        }
    }
}
