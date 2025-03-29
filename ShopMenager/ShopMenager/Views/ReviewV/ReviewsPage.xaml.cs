using ShopMenager.ViewModels.ReviewsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.ReviewV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsPage : ContentPage
    {
        ReviewsViewModel _viewModel;
        public ReviewsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = App.Services.GetService<ReviewsViewModel>();


        }
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            _viewModel.OnAppearing();

        }

    }
}