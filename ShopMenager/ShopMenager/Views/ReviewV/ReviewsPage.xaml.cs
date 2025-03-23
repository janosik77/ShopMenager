using ShopMenager.ViewModels.ReviewsVM;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.ReviewV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsPage : BasePage<ReviewsViewModel>
    {
        public ReviewsPage()
        {
            InitializeComponent();
        }
    }
}