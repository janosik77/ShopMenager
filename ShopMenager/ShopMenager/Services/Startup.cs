using Microsoft.Extensions.DependencyInjection;
using System;
using ShopMenager.Views;
using ShopMenager.ViewModels;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using ShopMenager.Models;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.ViewModels.DiscountVM;
using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.EmployeeVM;
using ShopMenager.ViewModels.OrderitemsVM;
using ShopMenager.ViewModels.PaymentVM;
using ShopMenager.ViewModels.ProductVM;
using ShopMenager.ViewModels.ReviewsVM;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.OrderItemsV;
using ShopMenager.Views.EmployeeV;
using ShopMenager.Views.ReviewV;
using ShopMenager.Views.PorductV;
using ShopMenager.Views.DiscountV;
using ShopMenager.Views.CategoryV;
using ShopMenager.Views.PaymentsV;

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
            services.AddTransient<CustomerDetailViewModel>();


            services.AddSingleton<CategoriesPage>();
            services.AddSingleton<CustomersPage>();
            services.AddSingleton<DiscountsPage>();
            services.AddSingleton<EmployeesPage>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<OrdersItemView>();
            services.AddSingleton<PaymentsPage>();
            services.AddSingleton<ProductPage>();
            services.AddSingleton<ReviewsPage>();
            services.AddTransient<AddCustomerView>();
            services.AddTransient<CustomerDetailsView>();


            //Rest api connection services
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddHttpClient<IApiService<Customer>, CustomerService>(client =>
            {
                client.BaseAddress = new Uri("http://10.0.2.2:5005");
            });
            services.AddHttpClient<IApiService<Review>, ReviewService>(client =>
            {
                client.BaseAddress = new Uri("http://10.0.2.2:5005");
            });

            
            return services.BuildServiceProvider();


        }
    }
}
