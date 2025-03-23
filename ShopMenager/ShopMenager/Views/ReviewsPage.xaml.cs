using ShopMenager.ViewModels;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsPage : BasePage<ReviewsPageViewModel>
    {
        public ReviewsPage()
        {
            InitializeComponent();
        }
    }
}