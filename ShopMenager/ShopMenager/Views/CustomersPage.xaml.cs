using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersPage : BasePage<CustomersPageViewModel>
    {
        public CustomersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as CustomersPageViewModel)?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            (BindingContext as CustomersPageViewModel)?.OnDisappearing();
            base.OnDisappearing();
        }
    }
}