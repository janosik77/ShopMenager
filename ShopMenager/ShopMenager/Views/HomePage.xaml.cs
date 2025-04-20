using ShopMenager.ViewModels;
using System;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        private HomePageViewModel vm;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = vm = App.Services.GetService<HomePageViewModel>();
        }
        protected override void OnAppearing ()
        {
            base.OnAppearing();
            vm.LoadCommand.Execute(null);
        }
    }
}