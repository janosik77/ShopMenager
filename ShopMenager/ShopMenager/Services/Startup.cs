using Microsoft.Extensions.DependencyInjection;
using System;
using ShopMenager.Views;
using ShopMenager.ViewModels;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using ShopMenager.Models;
using ShopMenager.Services.ApiService;
using ShopMenager.Views.Popups;
using ShopMenager.ViewModels.Popups;

namespace ShopMenager.Services
{
    public class Startup
    {
        public static IServiceProvider ConfigureService ()
        {
            var services = new ServiceCollection();

            //Nav services
            services.AddSingleton<CategoriesPageViewModel>();
            services.AddSingleton<CustomersPageViewModel>();
            services.AddSingleton<DiscountsPageViewModel>();
            services.AddSingleton<EmployeesPageViewModel>();
            services.AddSingleton<HomePageViewModel>();
            services.AddSingleton<MorePageViewModel>();
            services.AddSingleton<OrdersItemsViewModel> ();
            services.AddSingleton<PaymentsPageViewModel>();
            services.AddSingleton<ProductPageViewModel>();
            services.AddSingleton<ReviewsPageViewModel>();
            services.AddSingleton<SupplierPageViewModel>();
            services.AddTransient<AddCustomerPopupViewModel>();
            services.AddTransient<AddUpdateReviewPopioViewModel>();

            services.AddSingleton<CategoriesPage>();
            services.AddSingleton<CustomersPage>();
            services.AddSingleton<DiscountsPage>();
            services.AddSingleton<EmployeesPage>();
            services.AddSingleton<HomePage>();
            services.AddSingleton<MorePage>();
            services.AddSingleton<OrdersItems>();
            services.AddSingleton<PaymentsPage>();
            services.AddSingleton<ProductPage>();
            services.AddSingleton<ReviewsPage>();
            services.AddSingleton<SupplierPage>();
            services.AddTransient<AddCustomerPopup>();
            services.AddTransient<AddUpdateReviewPopup>();
            


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
