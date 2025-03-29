
using ShopMenager.ViewModels.OrderVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.OrderV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersPage : ContentPage
    {
        OrdersViewModel _viewModel;
        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = App.Services.GetService<OrdersViewModel>();
        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}