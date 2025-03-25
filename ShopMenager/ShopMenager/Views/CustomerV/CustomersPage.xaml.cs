using ShopMenager.ViewModels.CustomerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersPage : ContentPage
    {
        CustomersPageViewModel _viewModel;
        public CustomersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel =  App.Services.GetService<CustomersPageViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            
        }
    }
}