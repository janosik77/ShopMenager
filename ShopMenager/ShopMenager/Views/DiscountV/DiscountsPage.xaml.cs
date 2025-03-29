using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ShopMenager.ViewModels.OrderVM;
using ShopMenager.ViewModels.DiscountVM;

namespace ShopMenager.Views.DiscountV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscountsPage : ContentPage
    {
        DicountViewModel _viewModel;
        public DiscountsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = App.Services.GetService<DicountViewModel>();
        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}