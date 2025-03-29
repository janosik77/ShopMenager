using ShopMenager.ViewModels.ProductVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PorductV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {

        ProductViewModel _viewModel;
        public ProductPage()
        {
            InitializeComponent();
                BindingContext = _viewModel = App.Services.GetService<ProductViewModel>();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}