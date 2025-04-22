using Microsoft.Extensions.DependencyInjection;
using ShopMenager.Services;
using ShopMenager.Services.SessionMngr;
using ShopMenager.ViewModels;
using ShopMenager.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace ShopMenager
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            //In case of using HTTPS on local - that's only for testing 
            //- you can use preprocessor method for checking if we are running in development.
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            DependencyService.RegisterSingleton(new OrderService("https://10.0.2.2:7265",client));
            //SessionManager.LogoutAsync().GetAwaiter().GetResult();
            InitializeComponent();
           
            Services = Startup.ConfigureService(handler);
            if (SessionManager.IsLoggedIn)
            {
                MainPage = App.Services.GetService<AppShell>();
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
