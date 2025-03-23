using ShopMenager.Services;
using ShopMenager.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            //DependencyService.Register<MockDataStore>();
            InitializeComponent();
            
            Services = Startup.ConfigureService();           
            MainPage = new AppShell();
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
