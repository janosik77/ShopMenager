
using ShopMenager.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ShopMenager.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel _viewModel;
        public CategoriesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = App.Services.GetService<CategoriesViewModel>();
        }

        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }
    }
}